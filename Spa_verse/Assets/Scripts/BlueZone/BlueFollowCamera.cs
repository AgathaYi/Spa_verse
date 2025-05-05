using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlueFollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;

    void Start()
    {
        if (target == null)
        {
            return;
        }

        //거리유지하며 이동
        offsetX = transform.position.x - target.position.x; 
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 position = transform.position;
        position.x = target.position.x + offsetX;
        transform.position = position;
    }
}
