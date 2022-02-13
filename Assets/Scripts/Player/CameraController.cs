using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public int maxDeviationLeft = 0;
    public int maxDeviationRight = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(target != null)
        {
            float shift = target.position.x - transform.position.x;
            transform.Translate(new Vector3(shift, 0, 0));
        }
    }
}
