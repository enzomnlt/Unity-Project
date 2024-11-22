using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject capsule;

    void Start()
    {
        SpawnCapsules(10);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) // Press 1 to spawn 1 capsule
        {
            SpawnCapsules(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Press 2 to spawn 5 capsule
        {
            SpawnCapsules(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // Press 3 to spawn 10 capsule
        {
            SpawnCapsules(10);
        }
    }

    public void SpawnCapsules(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newCapsule = Instantiate(capsule, new Vector3(56, 9, 50), Quaternion.identity);
            NavMeshAgent agent = newCapsule.GetComponent<NavMeshAgent>();
            agent.enabled = true;
        }
    }
}