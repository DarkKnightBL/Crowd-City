using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private int spawnTimes, spawnAmount,startSpawn;
    [SerializeField] private float spawnDur;

    [SerializeField] private GameObject enemy, enemyParent;

    // Start is called before the first frame update
    private void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            for (int j = 0; j < startSpawn; j++)
            {
                GameObject temp = Instantiate(enemy, spawnPoints[i].transform.position, quaternion.identity);
                temp.transform.parent = enemyParent.transform;
            }
        }
        Invoke("Spawn", Random.Range(-spawnDur, spawnDur) * 3);
    }
    
    void Spawn()
    {
        for (int i = 0; i < spawnTimes - 1; i++)
        {
            for (int j = 0; j < spawnAmount; j++)
            {
                GameObject temp = Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, quaternion.identity);
                temp.transform.parent = enemyParent.transform;
            }
        }
        Invoke("Spawn", Random.Range(-spawnDur, spawnDur));
    }
}
