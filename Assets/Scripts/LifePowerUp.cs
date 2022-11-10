using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : Powerup
{
    public float livesToAdd;
    public LifePowerUp powerup;
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
        if(target.GetComponent<Pawn>().playerController.playerLives != 0)
        {
            target.GetComponent<Pawn>().playerController.playerLives += 1;
        }
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
