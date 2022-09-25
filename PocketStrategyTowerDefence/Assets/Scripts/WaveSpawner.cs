using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemy;

    public float cooldown;
    public float countdown;

    private int waveNumber = 0;

    public Transform spawnPoint;

    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = cooldown;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        
        waveNumber++;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
