using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObstacleMovement : MonoBehaviour 
{
    public float speed;
    public Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public abstract Vector3 GetNextPosition(Transform transform);

    public abstract void Interaction();

}
