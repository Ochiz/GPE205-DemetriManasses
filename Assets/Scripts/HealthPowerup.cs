using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class HealthPowerup : Powerup
{
    public float healthToAdd;



    public HealthPowerup powerup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Apply(PowerupManager target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if(targetHealth != null)
        {
            targetHealth.Heal(healthToAdd, target.GetComponent<Pawn>());  
        }
    }

    public override void Remove(PowerupManager target)
    {

    }
    public void OnTriggerEvent(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        if(powerupManager != null)
        {
            powerupManager.Add(powerup);
            Destroy(gameObject);
        }
        

    }
}
