using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishCollector : ScaryThing
{
    public GameObject binBagPrefab;
    public float binBagYpos;
    private GameObject binBags;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        scareType = ScaryThingType.RubbishCollector;

        // create a pile of bin bags
        if(binBagPrefab != null)
        {
            binBags = Instantiate(binBagPrefab, new Vector3(transform.position.x, binBagYpos, transform.position.z), Quaternion.identity);
        }
    }

    protected override void Activate(PlayerController player)
    {
        base.Activate(player);

        Debug.Log("activating Rubbish Collector");
        player.React(this);
    }

    private void OnDestroy()
    {
        if(binBags != null)
        {
            Destroy(binBags);
        }
    }
}
