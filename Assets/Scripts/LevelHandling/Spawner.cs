using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;

    public int maxObstacles;
    public int maxDistance;

    public List<GameObject> unlimitedSpawnables = new List<GameObject>();
    public List<GameObject> limitedSpawnables = new List<GameObject>();
    private List<GameObject> obstacles = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        while (player != null && obstacles.Count < maxObstacles && (unlimitedSpawnables.Count > 0 || limitedSpawnables.Count > 0))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Debug.Log("spawning!");
        Vector3 playerPosition = player.transform.position;
        float xPos = Random.value > 0.5 ? playerPosition.x + maxDistance : playerPosition.x - maxDistance;
        float yPos = Random.Range(-4, 0.5f);
        Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
        if (limitedSpawnables.Count > 0 && Random.value > 0.95)
        {
            int x = Random.Range(0, limitedSpawnables.Count);
            GameObject newObstacle = limitedSpawnables[x];
            Instantiate(newObstacle, spawnPosition, Quaternion.identity);
            obstacles.Add(newObstacle);
            limitedSpawnables.RemoveAt(x);
        }
        else if (unlimitedSpawnables.Count > 0)
        {
            int x = Random.Range(0, unlimitedSpawnables.Count);
            GameObject newObstacle = unlimitedSpawnables[x];
            obstacles.Add(newObstacle);
            Instantiate(newObstacle, spawnPosition, Quaternion.identity);
        }
    }
}
