using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoider : IObstacleMovement
{
    // Avoiders will move right-to-left until some trigger occurs, then a timer starts
    // When the timer ends, the Avoider runs away left-to-right. Escape speed can be set separately from normal speed
    // A separate trigger can prevent the running away stage
    // Triggers are *not* handled by the Avoider itself
    // Another script should check for whichever conditions are appropriate and then call Avoider.Interact() / Avoider.Disable()

    public float escapeSpeed;

    public float timeBeforeEscaping;
    private float currentTimeUntilEscape;
    public bool valid;

    private bool counting;
    private bool isEscaping;

    // Update is called once per frame
    public void Update()
    {
        if (counting && valid)
        {
            currentTimeUntilEscape -= Time.deltaTime;
            Debug.Log("currentTimeUntilEscape = " + currentTimeUntilEscape + "; valid = " + valid);
        }
        if ( valid && currentTimeUntilEscape < 0)
        {
            isEscaping = true;
            counting = false;
        }
    }

    public override Vector3 GetNextPosition(Transform transform)
    {
        Vector3 pos = transform.position;
        Vector3 movementVector = new Vector3(isEscaping ? 1 : -1, 0, 0);
        movementVector *= (isEscaping ? escapeSpeed : speed) * Time.deltaTime;
        if(animator != null)
        {
            animator.SetFloat("xSpeed", movementVector.x);
        }
        pos += movementVector;
        return pos;
    }

    public override void Interaction()
    {
        counting = false;
        valid = false;
    }

    public void StartCountdown()
    {
        if (valid)
        {
            currentTimeUntilEscape = timeBeforeEscaping;
            counting = true;
        }
    }
}
