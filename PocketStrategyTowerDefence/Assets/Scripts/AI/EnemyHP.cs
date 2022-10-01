using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //this is literally just a copy of the placeable tower stats but in a separate script
    public int maxHealth = 100;
    public int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
