using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Vector3 offset = new(0f, 0f, -1f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] public Transform target;

    private void Update()
    {
        MakePlayerCameraFollow();
    }

    private void MakePlayerCameraFollow()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        // transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
