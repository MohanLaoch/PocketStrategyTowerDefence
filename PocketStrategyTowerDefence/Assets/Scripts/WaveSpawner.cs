using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemy;

    public float cooldown;
    public float countdown;

    private int waveNumber = 1;
    
    public float minValueX;
    public float minValueZ;
    public float maxValueX;
    public float maxValueZ;

    public float spawnPointX;
    public float spawnPointY;
    public float spawnPointZ;

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
        
        //waveNumber++;
    }

    private void SpawnEnemy()
    {
        spawnPointX = Random.Range(minValueX, maxValueX);
        spawnPointZ = Random.Range(minValueZ, maxValueZ);
        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
        
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
