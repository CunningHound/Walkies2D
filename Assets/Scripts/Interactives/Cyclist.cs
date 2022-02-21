using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclist : MovingObstruction
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        type = MovingObstructionType.Cyclist;
    }

    protected override void Activate(PlayerController player)
    {
        base.Activate(player);
        Debug.Log("Activating cyclist");

        player.React(this);
        // TODO: particle effects/smoke/etc?
    }
}
