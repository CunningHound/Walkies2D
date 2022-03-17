using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : IObstacleMovement
{
    // simple mover only ever moves right-to-left

    override public Vector3 GetNextPosition(Transform transform)
    {
        // stick to 1d for now
        float xTarget = -100;

        float xPosition = transform.position.x;
        if(xPosition < xTarget)
        {
            return (transform.position + new Vector3(Time.deltaTime * speed, 0, 0));
        }
        else
        {
            return (transform.position + new Vector3(-Time.deltaTime * speed, 0, 0));
        }
    }

    public override void Interaction()
    {
        // nothing to do here
    }
}
