using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreChangeIndicator : MonoBehaviour
{
    public TMP_Text text;

    public void Display(int amount)
    {
        text.text = amount.ToString();
        Destroy(gameObject, 1);
    }
}
