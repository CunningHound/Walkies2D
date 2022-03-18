using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryPlacer : MonoBehaviour
{
    // just places a static object somewhere, depending on the position of the parent
    // i.e. bin bags above and below rubbish collectors

    public GameObject accessory;

    public bool useParentX;
    public float x;

    public bool useParentY;
    public float y;

    public bool disappearWithParent;
    private GameObject createdAccessory;

    // Start is called before the first frame update
    void Start()
    {
        createdAccessory = Instantiate(accessory, new Vector3(PickX(), PickY(), 0), Quaternion.identity);
    }

    void OnDelete()
    {
        if(createdAccessory != null)
        {
            Destroy(createdAccessory);
        }
    }

    float PickX()
    {
        return useParentX ? transform.position.x : x;
    }

    float PickY()
    {
        return useParentY ? transform.position.y : y;
    }
}
