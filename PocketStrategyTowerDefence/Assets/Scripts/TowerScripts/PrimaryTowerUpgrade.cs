using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrimaryTowerUpgrade : MonoBehaviour
{
    public GameObject[] levels;

    int currentLevel = 0;

    public bool invulnerable;
    private float cooldownTime = 1f;

    [Header("HealthBar")]

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public int healthUpgrade = 50;

    public TMP_Text hpText;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        hpText.text = currentHealth + "/" + maxHealth.ToString();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        StartCoroutine(DamageCooldown());
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && !invulnerable)
        {
            TakeDamage(1);
        }
    }

    IEnumerator DamageCooldown()
    {
        invulnerable = true;
        yield return new WaitForSeconds(cooldownTime);
        invulnerable = false;
    }
}
