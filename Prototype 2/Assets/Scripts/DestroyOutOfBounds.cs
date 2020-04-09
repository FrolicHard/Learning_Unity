using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 35;
    private float lowerBound = -5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy projectiles that didn't hit their target
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        //Destroy hungry animals that got past the player and trigger
        //a Game Over message in the console log
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
