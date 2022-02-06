using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoider : MonoBehaviour
{
    // Avoiders will run away from Gaika after spotting her
    // onTriggerEnter2D starts a timer, when the timer ends they leave
    public float timeBeforeEscaping;
    private float currentTimeUntilEscape;
    public bool valid;
    public bool randomUnscaredMovement;

    public float normalSpeed;
    public float escapeSpeed;

    private bool counting;
    private GameObject whatToAvoid;

    float xDestination;
    float yDestination;

    private bool isEscaping;

    // Start is called before the first frame update
    void Start()
    {
        counting = false;
        currentTimeUntilEscape = timeBeforeEscaping;

        isEscaping = false;

        xDestination = Random.value > 0.5 ? -100 : 200;
        yDestination = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // get unit vector for movement
        if(VectorToDestination().magnitude < 0.5)
        { 
            // pick new destination
        }
        Vector3 movementVector = VectorToDestination();
        movementVector.Normalize();
        movementVector *= (isEscaping? escapeSpeed : normalSpeed);
        transform.parent.transform.position += movementVector * Time.deltaTime;
        Animator animator = GetComponentInParent<Animator>();
        if(animator != null)
        {
            animator.SetFloat("xSpeed", movementVector.x);
        }

        if (counting)
        {
            currentTimeUntilEscape -= Time.deltaTime;
        }
        if (currentTimeUntilEscape < 0)
        {
            counting = false;
            currentTimeUntilEscape = timeBeforeEscaping;

            if (whatToAvoid != null)
            {
                Avoid(whatToAvoid.transform);
                whatToAvoid = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger!");
        GameObject other = collision.gameObject;
        PlayerController player = other.GetComponent<PlayerController>();
        if (valid && player != null)
        {
            counting = true;
            whatToAvoid = player.gameObject;
        }
    }

    void Avoid(Transform avoidanceTarget)
    {
        isEscaping = true;
        Debug.Log("avoiding!");
        float xPos = transform.position.x;
        if(avoidanceTarget.position.x < xPos)
        {
            xDestination = 10000;
        }
        else
        {
            xDestination = -10000;
        }
    }

    private Vector3 VectorToDestination()
    {
        Vector3 vectorToDestination = new Vector3(xDestination, yDestination, 0) - transform.position;
        return vectorToDestination;
    }
}
