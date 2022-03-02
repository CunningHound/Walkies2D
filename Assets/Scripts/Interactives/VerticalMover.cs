using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    // moves up and down repeatedly

    public float speed;
    public float waitTime;
    private bool waiting;
    private float waitTimeElapsed;

    public float maxY;
    public float minY;

    private bool movingUpwards;

    // Start is called before the first frame update
    void Start()
    {
        movingUpwards = false;
        waiting = false;
        transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        waitTimeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
            float deltaY = (movingUpwards ? speed : -speed) * Time.deltaTime;
            transform.position += new Vector3(0, deltaY, 0);

            if (transform.position.y > maxY || transform.position.y < minY )
            {
                waiting = true;
            }
        }
    }
}
