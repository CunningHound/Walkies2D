using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> floors = new List<GameObject>();
    public List<GameObject> levelBackgrounds = new List<GameObject>();

    public float leftEdge;
    public float rightEdge;

    public float floorHeight;
    public float backgroundHeight;
    public float pieceWidth;

    private GameObject floorParent;
    private GameObject backgroundParent;

    // Start is called before the first frame update
    void Start()
    {
        floorParent = new GameObject("floor pieces");
        backgroundParent = new GameObject("background pieces");
        Instantiate(floorParent, new Vector3(leftEdge, floorHeight, 0), Quaternion.identity);
        Instantiate(backgroundParent, new Vector3(leftEdge, backgroundHeight, 0), Quaternion.identity);

        if (floors.Count == 0 || levelBackgrounds.Count == 0)
        {
            return;
        }

        float currentEnd = leftEdge;
        int pieceCount = 0;
        while(currentEnd <= rightEdge)
        {
            GameObject newFloor = Instantiate(floors[Random.Range(0,floors.Count)], new Vector3(currentEnd, floorHeight, 0), Quaternion.identity, floorParent.transform);
            newFloor.name = "floor" + pieceCount.ToString();

            GameObject newBackground = Instantiate(levelBackgrounds[Random.Range(0,levelBackgrounds.Count)], new Vector3(currentEnd, backgroundHeight, 0), Quaternion.identity, backgroundParent.transform);
            newBackground.name = pieceCount.ToString();

            currentEnd += pieceWidth;
            pieceCount++;
        }
    }
}
