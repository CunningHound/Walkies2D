using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishCollector : ScaryThing
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        scareType = ScaryThingType.RubbishCollector;
    }

    protected override void Activate(PlayerController player)
    {
        base.Activate(player);

        Debug.Log("activating Rubbish Collector");
        player.React(this);
    }
}
