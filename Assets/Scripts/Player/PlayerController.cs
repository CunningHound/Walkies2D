using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxY;
    public float minY;

    private bool sitting;
    public GameObject cameraTarget;
    public float cameraTargetMoveAheadDistance;
    public float cameraTargetMoveAheadSpeed;

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
        Time.timeScale = 1;
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

        if (cameraTarget != null)
        {
            if (movement.x > 0)
            {
                float localXTarget = Mathf.Lerp(cameraTarget.transform.localPosition.x, cameraTargetMoveAheadDistance, cameraTargetMoveAheadSpeed * Time.deltaTime);
                cameraTarget.transform.localPosition = new Vector3(localXTarget, 0, 0);
            }
            else
            {
                float localXTarget = Mathf.Lerp(cameraTarget.transform.localPosition.x, 0, cameraTargetMoveAheadSpeed * Time.deltaTime);
                cameraTarget.transform.localPosition = new Vector3(localXTarget, 0, 0);
            }
        }
    }

    private void LoseLife()
    {
        Debug.Log("[PlayerController::LoseLife] lose life");
        if(livesManager != null)
        {
            livesManager.LoseLife();
        }
    }

    public void React(ScaryThing scaryThing)
    {
        Debug.Log("[PlayerController::React] reacting to ScaryThing " + scaryThing.transform.parent.name);
        if (scoreManager != null)
        {
            switch (scaryThing.scareType)
            {
                case ScaryThingType.BigBlackDog:
                    scoreManager.Penalise(scaryThing.scareType);
                    LoseLife();
                    break;
                case ScaryThingType.Jogger:
                case ScaryThingType.RubbishCollector:
                    if (sitting)
                    {
                        ;
                    }
                    else
                    {
                        scoreManager.Penalise(scaryThing.scareType);
                        LoseLife();
                    }
                    break;
            }
        }
    }
}
