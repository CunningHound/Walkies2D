using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObstacleMovement : MonoBehaviour 
{
    public float speed;
    public float speedVariation;
    public Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        if( speedVariation != 0 )
        {
            speed = speed + Random.Range(-speedVariation, speedVariation);
        }
    }

    public abstract Vector3 GetNextPosition(Transform transform);

    public abstract void Interaction();

}
