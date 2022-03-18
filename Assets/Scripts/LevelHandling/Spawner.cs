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

    public float maxY;
    public float minY;

    public List<GameObject> unlimitedSpawnables = new List<GameObject>();
    public List<GameObject> limitedSpawnables = new List<GameObject>();
    private List<GameObject> obstacles = new List<GameObject>();
    private int obstacleCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        obstacleCount = 0;
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
        CleanDistantObstacles();
    }

    private void CleanDistantObstacles()
    {
        for(int i = obstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = obstacles[i];
            // fudge maxDistance a little bit to avoid things flickering in and immediately back out when the player changes direction
            if (obstacle != null && Mathf.Abs(obstacle.transform.position.x - player.transform.position.x) > (maxDistance + 5) )
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
        float yPos = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
        if (limitedSpawnables.Count > 0 && (Random.value > 0.95 || unlimitedSpawnables.Count == 0) )
        {
            int x = Random.Range(0, limitedSpawnables.Count);
            GameObject newObstacle = Instantiate(limitedSpawnables[x], spawnPosition, Quaternion.identity);
            obstacles.Add(newObstacle);
            newObstacle.name = limitedSpawnables[x].name + obstacleCount;
            obstacleCount++;
            limitedSpawnables.RemoveAt(x);
        }
        else if (unlimitedSpawnables.Count > 0)
        {
            int x = Random.Range(0, unlimitedSpawnables.Count);
            GameObject newObstacle = Instantiate(unlimitedSpawnables[x], spawnPosition, Quaternion.identity);
            obstacles.Add(newObstacle);
            newObstacle.name = unlimitedSpawnables[x].name + obstacleCount;
            obstacleCount++;
        }
    }
}
