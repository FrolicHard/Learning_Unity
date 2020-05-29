using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs;
    private float spawnRangeX = 75;
    private float startDelay = 0.1f;
    private float spawnInterval = 0.065f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomObstacle()
    {
        //Randomly generate obstacle index and spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, transform.position.z); 

        int obstacleIndex = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[obstacleIndex], spawnPos,
        prefabs[obstacleIndex].transform.rotation);
        
    }
}
