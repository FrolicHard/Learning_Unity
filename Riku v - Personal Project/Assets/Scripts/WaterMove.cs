using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(60,1,-7.5f);
    private Vector3 velocity = Vector3.zero;

    private Vector3 waterlevel = new Vector3 (0,1,0);
    
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}