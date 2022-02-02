using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputX, 0, inputZ);
        if (movement.magnitude > 1)
        {
            movement = movement / movement.magnitude;
        }

        if (movement.magnitude > 0)
        {
            transform.LookAt(transform.position + movement);
            transform.position = transform.position + (movement * speed * Time.deltaTime);
        }
    }
}
