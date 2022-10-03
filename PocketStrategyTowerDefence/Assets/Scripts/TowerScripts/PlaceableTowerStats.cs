using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTowerStats : MonoBehaviour
{
    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;
    public bool invulnerable;
    private float cooldownTime = 1f;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        invulnerable = false;
    }
    
    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TakeDamage(20);
        }
        */
        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("DestroyTower");
            Destroy(this.gameObject);
        }
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && !invulnerable)
        {
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        StartCoroutine(DamageCooldown());
    }

    IEnumerator DamageCooldown()
    {
        invulnerable = true;
        yield return new WaitForSeconds(cooldownTime);
        invulnerable = false;
    }

}
