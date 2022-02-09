using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLayerHandler : MonoBehaviour
{
    private Vector3 position;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = (int)(-position.y*100);
        }
    }
}
