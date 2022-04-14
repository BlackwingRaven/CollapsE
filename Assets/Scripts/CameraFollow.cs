using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    public float YOffset = 0.0f;
    private Vector3 _velocity = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + YOffset, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }
}
