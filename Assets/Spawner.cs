using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject capsule;

    void Start()
    {
        for(int i = 0; i < 10; i++) // Spawn 10 capsules at the start
        {
            Instantiate(capsule, new Vector3(46, 6, 37), Quaternion.identity);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) // Press 1 to spawn 1 capsule
        {
            Instantiate(capsule, new Vector3(46, 6, 37), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for(int i = 0; i < 5; i++) // Press 2 to spawn 5 capsules
            {
                Instantiate(capsule, new Vector3(46, 6, 37), Quaternion.identity);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            for(int i = 0; i < 10; i++) // Press 3 to spawn 10 capsules
            {
                Instantiate(capsule, new Vector3(46, 6, 37), Quaternion.identity);
            }
        }
    }
}