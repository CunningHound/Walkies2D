using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleData obstacle;

    protected Vector3 targetPosition;

    public float speed;
    public float acceleration;
    public float deceleration;
    private float currentSpeed;

    private bool obstructed;
    public float obstructionTime;
    private float obstructionTimer;
    
    protected virtual void Start()
    {
        // nothing complex for now
        Vector3 pos = transform.position;
        targetPosition = new Vector3(pos.x - 100, pos.y, pos.y); 
    }

    private void Update()
    {
        if (obstructed)
        {
            obstructionTimer += Time.deltaTime;
            if(obstructionTimer > obstructionTime)
            {
                obstructed = false;
            }
        }

        if (!obstructed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, speed, acceleration * Time.deltaTime);
            transform.position = GetNextPosition();
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, deceleration * Time.deltaTime);
            transform.position = GetNextPosition();
        }
    }

    private Vector3 GetNextPosition()
    {
        // just 1d for now
        Vector3 movementDirection = targetPosition - transform.position;
        movementDirection.Normalize(); 
        return transform.position + movementDirection * currentSpeed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            obstacle.Activate(player);
        }
    }
}
