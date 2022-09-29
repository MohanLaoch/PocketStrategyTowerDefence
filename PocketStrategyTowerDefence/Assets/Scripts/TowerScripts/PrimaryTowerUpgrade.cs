using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryTowerUpgrade : MonoBehaviour
{
    public GameObject[] levels;

    int currentLevel = 0;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Upgrade();
        }
    }

    public void Upgrade()
    {
        if(currentLevel < levels.Length - 1)
        {
            currentLevel++;
            SwitchObject(currentLevel);
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
