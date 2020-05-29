using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloat : MonoBehaviour
{
    //public properties
    public float airDrag = 1;
    public float waterDrag = 10;
    public Transform[] floatPoints;
    public bool attachTosurface;

    //used components
    protected Rigidbody rb;
    protected Waves waves;

    //Water line
    protected float waterLine;
    protected Vector3[] waterLinePoints;

    //help vectors
    protected Vector3 centerOffset;
    protected Vector3 smoothVectorRotation;
    protected Vector3 targetUp;
    public Vector3 center 
    {
        get { return transform.position + centerOffset;}
    } 
    // Start is called before the first frame update
    void Awake()
    {
        waves = FindObjectOfType<Waves>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        //Compute Center
        waterLinePoints = new Vector3[floatPoints.Length];
        for (int i = 0; i < floatPoints.Length; i++)
        {
            waterLinePoints[i] = floatPoints[i].position;
        }
        centerOffset = PhysicsHelper.GetCenter(waterLinePoints) - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // default water surface
        var newWaterLine = 0f;
        var pointUnderWater = false;

        //set waterLinePoints and waterLine
        for (int i = 0; i < floatPoints.Length; i++)
        {
            //height
            waterLinePoints[i] = floatPoints[i].position;
            waterLinePoints[i].y = waves.GetHeight(floatPoints[i].position);
            newWaterLine += waterLinePoints[i].y / floatPoints.Length;
            if (waterLinePoints[i].y > floatPoints[i].position.y)
            {
                pointUnderWater = true;
            }
        }
        var waterLineDelta = newWaterLine - waterLine;
        waterLine = newWaterLine;

        //gravity
        var gravity = Physics.gravity;
        rb.drag = airDrag;

        if (waterLine > center.y)
        {
            rb.drag = waterDrag;
            //underwater
            if (attachTosurface)
            {
                //attach to water surface
                rb.position = new Vector3(rb.position.x, waterLine - centerOffset.y, rb.position.z);
            }
            
            else
            {
            //go up.
            gravity = -Physics.gravity;
            transform.Translate(Vector3.up * waterLineDelta * 0.9f);              
            }

        }
        rb.AddForce(gravity * Mathf.Clamp(Mathf.Abs(waterLine - center.y), 0, 1)); //The maths part is to stop jitter when the object is on the surface

        //compute upvector
        targetUp = PhysicsHelper.GetNormal(waterLinePoints);

        //rotation
        if (pointUnderWater)
        {
            //attach to water surface
            targetUp = Vector3.SmoothDamp(transform.up, targetUp, ref smoothVectorRotation, 0.2f);
            rb.rotation = Quaternion.FromToRotation(transform.up, targetUp) * rb.rotation;
        }
    }
}
