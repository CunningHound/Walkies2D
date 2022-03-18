using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : IObstacleMovement
{
    // moves up and down repeatedly

    public float waitTime;
    private bool waiting;
    private float waitTimeElapsed;

    public float maxY;
    public float minY;

    private bool movingUpwards;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        movingUpwards = Random.Range(0f,1f) > 0.5;
        waiting = false;
        waitTimeElapsed = 0;
    }

    public override Vector3 GetNextPosition(Transform transform)
    {
        Vector3 pos = transform.position;
        if (waiting)
        {
            waitTimeElapsed += Time.deltaTime;
            if(waitTimeElapsed > waitTime)
            {
                waitTimeElapsed = 0;
                waiting = false;
                movingUpwards = !movingUpwards;
            }
        }
        else
        {
            float ySpeed = movingUpwards ? speed : -speed;
            float deltaY = ySpeed * Time.deltaTime;
            animator.SetFloat("ySpeed", ySpeed);

            pos += new Vector3(0, deltaY, 0);

            if (pos.y > maxY)
            {
                pos.y = maxY;
                waiting = true;
                if(animator != null)
                {
                    animator.SetTrigger("waiting top");
                }
            }
            else if (pos.y < minY)
            {
                pos.y = minY;
                waiting = true;
                if(animator != null )
                {
                    animator.SetTrigger("waiting bottom");
                }
            }

        }
        return pos;
    }

    public override void Interaction()
    {
        // nothing to do here
    }
}
