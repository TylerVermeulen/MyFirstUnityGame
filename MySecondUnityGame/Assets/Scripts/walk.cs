using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class walk : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    public Transform goal;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = goal.position; 
    }

    // Update is called once per frame
    void Update()
    {
        // navMeshAgent.Move()
        navMeshAgent.destination = goal.position;
    }
}
