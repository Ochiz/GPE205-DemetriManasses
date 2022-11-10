using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ScorePowerup : Powerup
{
    public float scoreToAdd;
    public ScorePowerup powerup;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Apply(PowerupManager target)
    {
        
        target.GetComponent<Pawn>().playerController.AddScore(scoreToAdd);
        
    }

    public override void Remove(PowerupManager target)
    {
        target.Remove(powerup);
    }
    public void OnTriggerEvent(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        if (powerupManager != null)
        {
            powerupManager.Add(powerup);
            Destroy(gameObject);
        }


    }
}
