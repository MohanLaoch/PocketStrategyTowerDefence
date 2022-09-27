using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public GameObject[] upgrades;

    int currentUpgrade = 0;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Fire();
        }
    }

    public void Fire()
    {
        currentUpgrade = 1;
        SwitchObject(currentUpgrade);
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
