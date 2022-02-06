using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryThing : MonoBehaviour
{
    public ScaryThingType scareType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.React(this);
            Activate(); 
        }
    }

    void Activate()
    {
    }
}
