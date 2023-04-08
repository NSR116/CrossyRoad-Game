using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float motionSpeed = 0.35f;
    [SerializeField] private Transform playerPosition;
    private Vector3 cameraPosition;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = transform.position;
        offset = cameraPosition - playerPosition.position;
    }

    void LateUpdate()
    {
        moveCamera();
    }

    private void moveCamera()
    {
        Vector3 endPosition = playerPosition.position + offset;
        Vector3 targetPosition = new Vector3(endPosition.x, endPosition.y, endPosition.z < cameraPosition.z ? cameraPosition.z : endPosition.z);

        transform.position = Vector3.Lerp(cameraPosition, targetPosition, motionSpeed);
        cameraPosition = targetPosition;
    }
}
