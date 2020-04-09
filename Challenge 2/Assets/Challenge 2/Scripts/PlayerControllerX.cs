using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spawnRate = 0.8f;
    private float lastSpawn = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > spawnRate + lastSpawn)
            {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastSpawn = Time.time;
            }
        }
    }
}
