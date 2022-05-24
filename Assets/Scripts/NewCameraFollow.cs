using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    //Lo que se esta siguiendo
    public Transform target;

    //Hace la velocidad cero
    Vector3 velocity = Vector3.zero;

    //Tiempo para seguir al objetivo
    public float smoothTime = .15f;

    //Activar y asignar el valor maximo para la camara en X
    public bool xMaxEnabled = false;
    public float xMaxValue = 0f;

    //Activar y asignar el valor minimo para la camara en X
    public bool xMinEnabled = false;
    public float xMinValue = 0f;

    public bool isYLocked = false;

    [SerializeField]
    public float yOffset;

    [SerializeField]
    protected float followSpeed;

    private void FixedUpdate()
    {
        //Posicion del objetivo
        Vector3 targetPos = target.position;

        //float yTarget = target.position.y + yOffset;

        //Bloqueo horizontal
        if (xMinEnabled && xMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, xMinValue, xMaxValue);

        else if (xMinEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, xMinValue, target.position.x);

        else if (xMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, xMaxValue);

        //Alinea la cámara y la posicion z del objetivo
        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
