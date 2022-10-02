using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTowerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool invulnerable;
    private float cooldownTime = 1f;

    private void Start()
    {
        currentHealth = maxHealth;
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
        StartCoroutine(DamageCooldown());
    }

    IEnumerator DamageCooldown()
    {
        invulnerable = true;
        yield return new WaitForSeconds(cooldownTime);
        invulnerable = false;
    }

}
