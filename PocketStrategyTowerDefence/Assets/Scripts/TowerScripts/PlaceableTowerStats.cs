using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTowerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TakeDamage(20);
        }

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
