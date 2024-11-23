using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject visitor;
    [SerializeField] private GameObject wanderer;

    void Start()
    {
        SpawnVisitors(9);
        SpawnWanderers(9);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Press 1 to spawn 10 visitors
        {
            SpawnVisitors(10);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Press 2 to spawn 25 visitors
        {
            SpawnVisitors(25);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // Press 3 to spawn 10 wanderers
        {
            SpawnWanderers(10);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) // Press 4 to spawn 25 wanderers
        {
            SpawnWanderers(25);
        }
    }

    public void SpawnVisitors(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newVisitor = Instantiate(visitor, new Vector3(50, 9, 45), Quaternion.identity);
            // Precaution if the reference visitor is disabled (visiting a structure) :
            NavMeshAgent agent = newVisitor.GetComponent<NavMeshAgent>();
            agent.enabled = true;
        }
    }
    public void SpawnWanderers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomPosition = new Vector3(50, 9, 45);
            GameObject newWanderer = Instantiate(wanderer, randomPosition, Quaternion.identity);
        }
    }
}