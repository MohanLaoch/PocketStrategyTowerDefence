using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public GameObject[] upgrades;

    public GameObject buttonPanel;

    int currentUpgrade = 0;

    public void Fire()
    {
        FindObjectOfType<AudioManager>().Play("UpgradeTowerFire");
        currentUpgrade = 1;
        SwitchObject(currentUpgrade);
        Destroy(buttonPanel);
    }

    public void Water()
    {
        FindObjectOfType<AudioManager>().Play("UpgradeTowerWater");
        currentUpgrade = 2;
        SwitchObject(currentUpgrade);
        Destroy(buttonPanel);
    }

    void SwitchObject(int upgrade)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (i == upgrade)
            {
                upgrades[i].SetActive(true);
            }
            else
            {
                upgrades[i].SetActive(false);
            }
        }
    }
}
