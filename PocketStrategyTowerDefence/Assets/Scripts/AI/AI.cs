using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform target;
    public Transform mainTower;
    public GameObject[] turretTowers;

    private float distanceToMain;
    private float distanceToTower;
    private float range = 15f;

    private float shortestDistance;

    public GameObject nearestTower;
    
    public NavMeshAgent Agent;

    private void Awake()
    {
        mainTower = GameObject.FindGameObjectWithTag("Central").GetComponent<Transform>();
        target = mainTower;
        Agent = GetComponent<NavMeshAgent>();
        nearestTower = null;
    }

    void Start()
    {
        Agent.SetDestination(target.position);
    }

    private void Update()
    {
        turretTowers = GameObject.FindGameObjectsWithTag("PlaceableTower");
        distanceToMain = Vector3.Distance(transform.position, mainTower.position);
        SetTarget();
    }

    private void SetTarget()
    {
        shortestDistance = Mathf.Infinity;

        foreach (GameObject tower in turretTowers)
        {
            distanceToTower = Vector3.Distance(transform.position, tower.transform.position);

            if (distanceToTower < distanceToMain)
            {
                shortestDistance = distanceToTower;
                nearestTower = tower;
            }

            if (nearestTower != null && shortestDistance <= range)
            {
                target = nearestTower.transform;
                Agent.SetDestination(target.position);
            }

            else
            {
                target = mainTower;
                Agent.SetDestination(target.position);
            }
        }

        if (turretTowers.Length == 0)
        {
            target = mainTower;
            Agent.SetDestination(target.position); 
        }

    }
}
