using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;

    public int maxObstacles;
    public int maxDistance;
    public int timeBetweenSpawns;
    private float minTimeUntilNextSpawn;

    public List<GameObject> unlimitedSpawnables = new List<GameObject>();
    public List<GameObject> limitedSpawnables = new List<GameObject>();
    private List<GameObject> obstacles = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        minTimeUntilNextSpawn = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        minTimeUntilNextSpawn -= Time.deltaTime;
        if (minTimeUntilNextSpawn <= 0)
        {
            if (player != null && obstacles.Count < maxObstacles && (unlimitedSpawnables.Count > 0 || limitedSpawnables.Count > 0))
            {
                minTimeUntilNextSpawn = timeBetweenSpawns;
                Spawn();
            }
        }
    }

    private void CleanDistantObstacles()
    {
        foreach(GameObject obstacle in obstacles)
        {
            if (Mathf.Abs(obstacle.transform.position.x - player.transform.position.x) > maxDistance )
            {
                obstacles.Remove(obstacle);
                Destroy(obstacle);
            }
        }
    }

    private void Spawn()
    {
        Vector3 playerPosition = player.transform.position;
        float xPos = playerPosition.x + maxDistance;
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
