using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoiderWatchdog : MonoBehaviour
{
    public Avoider avoider;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[Avoider::OnTriggerEnter2D] trigger!");
        GameObject other = collision.gameObject;
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && avoider != null && avoider.valid)
        {
            avoider.StartCountdown();
        }

    }
}
