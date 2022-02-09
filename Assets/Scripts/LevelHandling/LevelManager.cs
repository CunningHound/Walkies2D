using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            int currentPos = (int)Mathf.Floor(10*player.transform.position.x);
            if(currentPos > score)
            {
                score = currentPos;
            }
        }
    }
}
