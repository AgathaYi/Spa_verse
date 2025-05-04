using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed = 5f;
    public Vector2 minBound; // �ּ���ġ
    public Vector2 maxBound; // �ִ���ġ

    private Vector3 offset; // ī�޶�� Ÿ�� �Ÿ�

    void Start()
    {
        offset = transform.position - target.position;
    }
    
    void LateUpdate() // ĳ���� �̵� ���� ī�޶� �̵�
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z; // z�� ����

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBound.x, maxBound.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBound.y, maxBound.y);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed * Time.deltaTime);
    }
}
