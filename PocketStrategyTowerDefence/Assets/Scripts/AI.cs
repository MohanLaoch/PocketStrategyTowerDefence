using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Transform tower;
    public NavMeshAgent Agent;

    private void Awake()
    {
        tower = GameObject.FindGameObjectWithTag("Central").GetComponent<Transform>();
        Agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        Agent.SetDestination(tower.position);
    }
}
