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

    BlueGameManager blueGameManager = null;

    void Start()
    {
        blueGameManager = BlueGameManager.Instance; // 게임매니져의 어웨이크와 꼬이지 않도록 !
        animator = GetComponentInChildren<Animator>();
        blueRigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("애니메이터 X");
        }

        if (blueRigidbody == null)
        {
            Debug.LogError("리지드바디 X");
        }
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    blueGameManager.RestartGame();
                    isDead = false;
                    deathCooldown = 0.5f;
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
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

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        blueRigidbody.velocity = velocity;

        float angle = Mathf.Clamp(blueRigidbody.velocity.y * 5f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead)
        {
            return;
        }

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;

        blueGameManager.GameOver();
    }
}
