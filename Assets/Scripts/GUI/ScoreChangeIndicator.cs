using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreChangeIndicator : MonoBehaviour
{
    public TMP_Text text;

    public void Display(int amount)
    {
        if (amount == 0)
        {
            return;
        }
        Debug.Log(transform.position);
        text.text = amount.ToString();
        Destroy(gameObject, 1f);
    }
}
