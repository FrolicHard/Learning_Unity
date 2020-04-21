using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupIndicatorHelpScript : MonoBehaviour
{
    Transform t;
    public float fixedRotation = 5;  
    // Start is called before the first frame update
    void Start()
    {
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        t.eulerAngles = new Vector3 (0, fixedRotation, 0);
    }
}
