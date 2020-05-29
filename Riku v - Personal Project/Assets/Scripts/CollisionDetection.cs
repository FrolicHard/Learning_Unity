using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{   
    void OnCollisionEnter(Collision collisionInfo) 
    {
        //Check if the object hit was an obstacle

        if (collisionInfo.collider.tag == "Obstacle")
        {
        GetComponent<PlayerController>().enabled = false;
        FindObjectOfType<GameManager>().EndGame();
        }
    }
}
