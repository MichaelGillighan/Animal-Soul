using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewerCameraFollow : MonoBehaviour
{

    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = .2f;
    private Vector3 velocity;
    private float startingY;

    public bool boundaries;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    private void Start()
    {
        startingY = transform.position.y;
    }

    private void LateUpdate()
    {

        if (targets.Count == 0)
            return;

        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        newPosition.y = startingY; 
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

        if (boundaries)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.x),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)      
            return targets[0].position;
        
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)        
            bounds.Encapsulate(targets[i].position);
        
        return bounds.center;
    }
}
