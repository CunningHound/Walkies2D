using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryThing : MonoBehaviour
{
    public ObstacleData obstacleData;

    public float timeBetweenScares;
    protected bool isActive;
    protected float scareCountdown;

    public bool stillScaryWhenSitting;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        isActive = true;
        scareCountdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            if (scareCountdown > 0)
            {
                scareCountdown -= Time.deltaTime;
            }
            else
            {
                isActive = true;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[ScaryThing::OnTriggerEnter2D] trigger entered");
        if (isActive)
        {
            GameObject other = collision.gameObject;
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                Activate(player);
            }
        }
    }

    void Activate(PlayerController player)
    {
        if (!player.sitting || stillScaryWhenSitting)
        {
            obstacleData.Activate(player);
        }
    }
}
