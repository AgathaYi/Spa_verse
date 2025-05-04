using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseControl : MonoBehaviour // ����ü���� �θ�
{
    // �߷�, �浹ü, �̵�, ������, ���ݷ�, ü��, �������, ���ݿ���, �ൿ���� ...
    // Rigidbody2D, Collider2D, Animator, SpriteRenderer, AudioSource, Transform, GameObject
    // private : �ҹ��ڽ���.

    protected Rigidbody2D Rigidbody;

    [SerializeField] private SpriteRenderer CharacterFlip;

    protected Vector2 moveDirection = Vector2.zero;
    public Vector2 MoveDirection { get => moveDirection; }

    protected bool isRunning = false; // �޸��� ����

    // �ٶ󺸴� ����
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get => lookDirection; }

    protected StatHandler StatHandler;


    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        StatHandler = GetComponent<StatHandler>();
    }

    void Start()
    {
        
    }

    protected virtual void Update() // �� �����Ӹ��� ȣ��, ���� X, �Ϲ� 
    {
        KeyControl();
        Rotate(lookDirection);
    }


    protected virtual void FixedUpdate() // ������ ������Ʈ, �� �����Ӹ��� ȣ��
    {
        Move(moveDirection);
    }

    protected virtual void KeyControl()
    {
        // �ڽĿ��� �������̵�
    }

    // �̵� �ӵ�, ���� �̵�
    private void Move(Vector2 direction)
    {
        float runSpeed = StatHandler.MoveSpeed;

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
