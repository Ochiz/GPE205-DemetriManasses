using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public float killScoreToAdd;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die(Pawn source)
    {
        gameObject.GetComponent<PlayerController>().playerLives -= 1;
        if (gameObject.GetComponent<PlayerController>().playerLives <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            currentHealth = maxHealth;
        }
    }
    public void TakeDamage(float amount, Pawn source)
    {
        currentHealth = currentHealth - amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            Die(source);
            source.playerController.AddScore(killScoreToAdd);
        }
    }
    public void Heal(float amount, Pawn source)
    {
        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
