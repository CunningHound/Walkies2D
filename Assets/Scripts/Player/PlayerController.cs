using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxY;
    public float minY;

    private bool sitting;

    private LivesManager livesManager;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        livesManager = Globals.livesManager;
        scoreManager = Globals.scoreManager;
        if (scoreManager != null)
        {
            scoreManager.player = this;
        }
        sitting = true; 
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputX, inputY, 0);
        float magnitude = movement.magnitude;
        if( sitting && magnitude > 0 )
        {
            sitting = false;
        }
        if (magnitude > 1)
        {
            movement = movement / movement.magnitude;
        }

        if (movement.magnitude > 0)
        {
            Vector3 newPosition = transform.position + (movement * speed * Time.deltaTime);
            if(newPosition.y > maxY)
            {
                newPosition.y = maxY;
            }
            else if(newPosition.y < minY)
            {
                newPosition.y = minY;
            }
            transform.SetPositionAndRotation(newPosition,Quaternion.identity);
        }
    }

    private void loseLife()
    {
        Debug.Log("lose life");
        if(livesManager != null)
        {
            livesManager.loseLife();
        }
    }

    public void React(ScaryThing scaryThing)
    {
        Debug.Log("reacting to ScaryThing " + scaryThing.transform.parent.name);
        switch (scaryThing.scareType)
        {
            case ScaryThingType.BigBlackDog:
                loseLife();
                break;
            case ScaryThingType.Jogger:
            case ScaryThingType.RubbishCollector:
                if (sitting)
                {
                    ;
                }
                else
                {
                    loseLife();
                }
                break;
        }
        if(scoreManager != null)
        {
            scoreManager.Penalise(scaryThing.scareType);
        }
    }
}
