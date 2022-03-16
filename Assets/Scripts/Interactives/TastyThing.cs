using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastyThing : MonoBehaviour
{
    public TastyThingType type;
    public ObstacleData obstacleData;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            obstacleData.Activate(player);
            Destroy(gameObject, 0.5f);
        }
    }
}
