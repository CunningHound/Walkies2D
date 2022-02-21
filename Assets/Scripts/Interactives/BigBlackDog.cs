using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBlackDog : ScaryThing
{
    public Avoider avoider;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        scareType = ScaryThingType.BigBlackDog; 
    }

    protected override void Activate(PlayerController player)
    {
        base.Activate(player);
        Debug.Log("activating big black dog");

        player.React(this);
        if (avoider != null)
        {
            Debug.Log("[ScaryThing::Activate] invalidating avoider");
            avoider.valid = false;
        }
    }
}
