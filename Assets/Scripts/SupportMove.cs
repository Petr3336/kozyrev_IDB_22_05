using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class SupportMove : MonoBehaviour
{
    // Start is called before the first frame update
    
    public CircularDrive CD;
    float base_position;
    void Start()
    {
        base_position = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,base_position + CD.outAngle/1000);
    }
}
