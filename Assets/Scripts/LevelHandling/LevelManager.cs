using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public int score;

    // Start is called before the first frame update
    private void Awake()
    {
        Globals.levelManager = this;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
