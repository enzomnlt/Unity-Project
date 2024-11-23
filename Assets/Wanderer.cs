using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wanderer : MonoBehaviour
{
    public NavMeshAgent agent;
    public int minX = 35;
    public int maxX = 125;
    public int minZ = 10;
    public int maxZ = 100;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ChooseNewDestination();
    }

    void Update()
    {
        if (!agent.hasPath || agent.remainingDistance < 1.75f)
        {
            ChooseNewDestination();
        }
    }

    void ChooseNewDestination()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
        agent.SetDestination(randomPosition);
    }
}