using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // stick to 1d for now
        float xTarget = -100;

        float xPosition = transform.position.x;
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
