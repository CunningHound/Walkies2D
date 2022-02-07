using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxY;
    public float minY;

    private bool sitting;

    // Start is called before the first frame update
    void Start()
    {
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

    public void React(ScaryThing scaryThing)
    {
        switch (scaryThing.scareType)
        {
            case ScaryThingType.BigBlackDog:
                Debug.Log("Gaika: oh no! *barkbarkbark*");
                break;
            case ScaryThingType.Jogger:
                if (sitting)
                {
                    ;
                }
                else
                {
                    Debug.Log("Gaika: *barkbark* that was close!");
                }
                break;
            case ScaryThingType.RubbishCollector:
                break;
        }
    }
}
