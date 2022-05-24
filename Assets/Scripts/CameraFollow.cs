using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    protected Transform trackingTarget;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    /*
    [SerializeField]
    float
    */

    [SerializeField]
    protected float followSpeed;

    public bool isXLocked = false;

    public bool isYLocked = false;


    void Update()
    {       

        float xTarget = trackingTarget.position.x + xOffset;
        float yTarget = trackingTarget.position.y + yOffset;

        //trackingTarget.position = new Vector3(xTarget, yTarget, trackingTarget.position.z);

        float xNew = transform.position.x;
        if (!isXLocked)
            xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);

        float yNew = transform.position.y;
        if (!isYLocked)
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
        

        transform.position = new Vector3(xNew, yNew, transform.position.z);  

        
    }
}
