using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 50.0f;
    private float turnSpeed = 30.0f;
    public float panSpeed = 1.0F;
    private float startDelay = 10;
    private float repeatDelay = 10;
    private float horizontalInput;   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseSpeed", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        
        //Turn the vehicle 
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        transform.Rotate(Vector3.forward, panSpeed *horizontalInput * Time.deltaTime);
        
        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);           
    }
    void IncreaseSpeed()
    {
        speed+=5;
    }
}
