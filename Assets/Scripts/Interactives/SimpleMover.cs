using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    public float speed;
    public float xTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPosition = transform.position.x;
        if(Mathf.Abs(xPosition - xTarget) < 0.5 )
        {
            // set new value, don't care for now
        }
        if(xPosition < xTarget) // going right
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-Time.deltaTime * speed, 0, 0);
        }

    }
}
