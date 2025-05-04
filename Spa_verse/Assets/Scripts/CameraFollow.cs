using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed = 5f;
    public Vector2 minBound; // 최소위치
    public Vector2 maxBound; // 최대위치

    private Vector3 offset; // 카메라와 타겟 거리

    void Start()
    {
        offset = transform.position - target.position;
    }
    
    void LateUpdate() // 캐릭터 이동 이후 카메라 이동
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z; // z축 고정

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBound.x, maxBound.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBound.y, maxBound.y);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed * Time.deltaTime);
    }
}
