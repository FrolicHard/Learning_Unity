using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject[] prefabs;

    public float spawnInterval = 9.5f;
    private float startDelay = 0.1f;
    private float repeatRate = 10;
    private float strtDelay = 25;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTerrain", startDelay, spawnInterval);
        InvokeRepeating("SpawnFaster", strtDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnTerrain()
    {
        
        Vector3 spawnPos = transform.position; 

        int TerrainIndex = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[TerrainIndex], spawnPos,
        prefabs[TerrainIndex].transform.rotation);
    }

    void SpawnFaster()
    {
        if (spawnInterval < 1)
        {
        spawnInterval =1;
        }
        else
        {
        spawnInterval -= 1.5f;
        }
    }
}