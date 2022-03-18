using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMover : IObstacleMovement
{
    // smooth mover moves right-to-left, but stops and waits a moment when obstructed
    // some degree of acceleration/deceleration rather than immediate start/stop

    private bool obstructed = false;

    private float currentSpeed;
    public float acceleration;
    public float deceleration;

    public float pauseLength;
    private float pauseTimer;


    private void Update()
    {
        if (obstructed)
        {
            pauseTimer += Time.deltaTime;
            if(pauseTimer > pauseLength)
            {
                obstructed = false;
                pauseTimer = 0;
            }
        }
        if(animator != null)
        {
            animator.SetFloat("speed", currentSpeed);
        }
    }

    override public Vector3 GetNextPosition(Transform transform)
    {
        Vector3 pos = transform.position;
        if (!obstructed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, speed, acceleration * Time.deltaTime);
            return GetNextPosition(pos);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, deceleration * Time.deltaTime);
            return GetNextPosition(pos);
        }
    }

    public override void Interaction()
    {
        Debug.Log("[SmoothMover::Interaction] ");
        obstructed = true;
        pauseTimer = 0;
    }

    private Vector3 GetNextPosition(Vector3 pos)
    {
        // just 1d for now
        Vector3 movementDirection = new Vector3(-1, 0, 0);
        return pos + movementDirection * currentSpeed * Time.deltaTime;
    }


}
