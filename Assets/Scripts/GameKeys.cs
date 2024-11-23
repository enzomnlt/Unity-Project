using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameKeys : MonoBehaviour
{
    [SerializeField] private GameObject visitor;
    [SerializeField] private GameObject wanderer;

    void Start()
    {
        SpawnEntities(visitor, 9);
        SpawnEntities(wanderer, 9);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Press 1 to spawn 10 visitors
        {
            SpawnEntities(visitor, 10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Press 2 to spawn 25 visitors
        {
            SpawnEntities(visitor, 25);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // Press 3 to spawn 10 wanderers
        {
            SpawnEntities(wanderer, 10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) // Press 4 to spawn 25 wanderers
        {
            SpawnEntities(wanderer, 25);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // Press ESC to quit the game
        {
            Application.Quit();
        }
    }

    private void SpawnEntities(GameObject entity, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = new Vector3(44, 9, 44);
            GameObject newEntity = Instantiate(entity, spawnPosition, Quaternion.identity);

            // Precaution if the reference visitor is disabled (visiting a structure) :
            if (entity == visitor)
            {
                NavMeshAgent agent = newEntity.GetComponent<NavMeshAgent>();
                agent.enabled = true;
            }
        }
    }
}