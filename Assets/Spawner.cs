using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject capsule;

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            Instantiate(capsule, new Vector3(46, 6, 37), Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
