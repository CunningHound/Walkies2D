using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryThing : MonoBehaviour
{
    public ScaryThingType scareType;
    public float timeBetweenScares;
    protected bool isActive;
    protected float scareCountdown;

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

    protected virtual void Activate(PlayerController player)
    {
        Debug.Log("activating scarything");
        scareCountdown = timeBetweenScares;
    }
}
