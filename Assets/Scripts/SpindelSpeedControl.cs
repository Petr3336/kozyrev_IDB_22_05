using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SpindelSpeedControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spindel;
    public CircularDrive CD;

    private int speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spindel.transform.Rotate(new Vector3(0, 0, CD.linearMapping.value - 1));
    }
}
