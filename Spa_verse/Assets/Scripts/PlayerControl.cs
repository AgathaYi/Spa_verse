using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : BaseControl
{
    private Camera mainCamera;

    protected override void Awake()
    {
        base.Awake();
        mainCamera = Camera.main;
    }

    public void Init()
    {
        mainCamera = Camera.main;
    }

    protected override void KeyControl()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // 가로
        float vertical = Input.GetAxisRaw("Vertical"); // 세로
        moveDirection = new Vector2(horizontal, vertical).normalized;

        isRunning = Input.GetKey(KeyCode.LeftShift);

        //if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(Rigidbody.velocity.y) < 0.02f)
        //{
        //    Rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        //}

        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        lookDirection = worldPos - (Vector2)transform.position;

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    public override void Die()
    {
        base.Die();
        
    }
}
