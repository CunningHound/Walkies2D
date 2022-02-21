using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogger : ScaryThing
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        scareType = ScaryThingType.Jogger;
    }

    protected override void Activate(PlayerController player)
    {
        base.Activate(player);

        Debug.Log("activating jogger");
        player.React(this);
    }

}
