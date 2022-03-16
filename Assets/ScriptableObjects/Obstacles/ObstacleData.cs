using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle")]
public class ObstacleData : ScriptableObject {

    // base SO for all kinds of Obstacles etc.

    public int scoreCost = 0;
    public bool costLife = false;

    public ScoreManager scoreManager;

    public string animatorTriggerID;

    public List<AudioClip> interactionSounds;

    public void Activate(PlayerController player)
    {
        scoreManager.loseScore(scoreCost);
        if(costLife)
        {
            scoreManager.loseLife();
        }

        Debug.Log("length of sounds list = " + interactionSounds.Count);
        if(interactionSounds.Count > 0)
        {
            player.PlayClip(interactionSounds[Random.Range(0, interactionSounds.Count)]);
        }

        if(animatorTriggerID != "" && player.animator != null)
        {
            player.animator.SetTrigger(animatorTriggerID);
        }

    }

}
