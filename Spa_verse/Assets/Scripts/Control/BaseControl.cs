using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseControl : MonoBehaviour // 생명체들의 부모
{
    // 중력, 충돌체, 이동, 점프력, 공격력, 체력, 사망여부, 공격여부, 행동여부 ...
    // Rigidbody2D, Collider2D, Animator, SpriteRenderer, AudioSource, Transform, GameObject

    protected Rigidbody2D Rigidbody;

    [SerializeField] private SpriteRenderer CharacterFlip;

    protected Vector2 moveDirection = Vector2.zero;
    public Vector2 MoveDirection { get => moveDirection; }

    protected bool isRunning = false; // 달리기 여부

    // 바라보는 방향
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get => lookDirection; }

    protected MainPlayerHandler MainHandler;


    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        MainHandler = GetComponent<MainPlayerHandler>();
    }

    void Start()
    {
        
    }

    protected virtual void Update() // 매 프레임마다 호출, 물리 X, 일반 
    {
        KeyControl();
        Rotate(lookDirection);
    }


    protected virtual void FixedUpdate() // 물리적 업데이트, 매 프레임마다 호출
    {
        Move(moveDirection);
    }

    protected virtual void KeyControl()
    {
        // 자식에서 오버라이드
    }

    // 이동 속도, 실제 이동
    private void Move(Vector2 direction)
    {
        float runSpeed = MainHandler.MoveSpeed;

        if (isRunning)
        {
            runSpeed *= 1.8f;
        }

        direction = direction * runSpeed;
        Rigidbody.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        if (direction.x > 0)
        {
            CharacterFlip.flipX = false;
        }
        else if (direction.x < 0)
        {
            CharacterFlip.flipX = true;
        }
    }

    public virtual void Die()
    {
        Rigidbody.velocity = Vector2.zero;

        foreach (SpriteRenderer sprite in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = sprite.color;
            color.a = 0.3f;
            sprite.color = color;
        }

        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
        }

        Destroy(gameObject, 2f);
    }

}
