//new script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform sphere;
    Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - sphere.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 targetPos = sphere.position + offset;
        targetPos.x = 0;

        // Set the y-component to the initial camera position's y-coordinate
        targetPos.y = transform.position.y;
        
        // Keep only the z-component for following in the z-direction
        transform.position = new Vector3(0, targetPos.y, targetPos.z);
    }
}

