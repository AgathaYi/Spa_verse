using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer : MonoBehaviour
{
    Animator animator;
    Rigidbody2D blueRigidbody;

    public float flapForce = 6f;
    public float fowardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;
    bool isFlap = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        blueRigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("�ִϸ����� X");
        }

        if (blueRigidbody == null)
        {
            Debug.LogError("������ٵ� X");
        }
    }

    void Update()
    {
        if (isDead)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Vector3 velocity = blueRigidbody.velocity;
        velocity.x = fowardSpeed;


    }
}
