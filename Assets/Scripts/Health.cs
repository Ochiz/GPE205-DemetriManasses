using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public static int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    public abstract void Start();
    // Update is called once per frame
    public abstract void Update();
    public abstract void HealthChange(int healthAmount);
}
