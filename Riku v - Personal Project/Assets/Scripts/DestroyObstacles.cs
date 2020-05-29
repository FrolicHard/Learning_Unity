using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        //Destroy obstacles that the player managed to evade
        if (transform.position.z < Camera.main.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
