using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryTowerUpgrade : MonoBehaviour
{
    public GameObject[] levels;

    int currentLevel = 0;

    [Header("HealthBar")]

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public int healthUpgrade = 50;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void Upgrade()
    {
        if(currentLevel < levels.Length - 1)
        {
            currentLevel++;
            SwitchObject(currentLevel);
            maxHealth += healthUpgrade;
            currentHealth += healthUpgrade;
        }
    }

    void SwitchObject(int level)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (i == level)
            {
                levels[i].SetActive(true);
            }
            else
            {
                levels[i].SetActive(false);
            }
        }
    }
}
