using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    //this is literally just a copy of the placeable tower stats but in a separate script
    public int maxHealth;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            TakeDamage(25);
        }
        if (other.CompareTag("Fireball"))
        {
            TakeDamage(15);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDiesViolently");
            Destroy(this.gameObject);
        }
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
