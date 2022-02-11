using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryThing : MonoBehaviour
{
    public ScaryThingType scareType;
    public float timeBetweenScares;
    private bool isActive;
    private float scareCountdown;

    // Start is called before the first frame update
    void Start()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            GameObject other = collision.gameObject;
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.React(this);
                Activate();
            }
        }
    }

    void Activate()
    {
        scareCountdown = timeBetweenScares;
        Avoider avoider = gameObject.GetComponent<Avoider>();
        if(avoider != null)
        {
            Debug.Log("invalidating avoider");
            avoider.valid = false;
        }
    }
}
