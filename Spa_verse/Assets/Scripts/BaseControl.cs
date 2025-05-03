using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour // ����ü���� �θ�
{
    // �߷�, �浹ü, �̵�, ������, ���ݷ�, ü��, �������, ���ݿ���, �ൿ���� ...
    // Rigidbody2D, Collider2D, Animator, SpriteRenderer, AudioSource, Transform, GameObject
    // private : �ҹ��ڽ���.

    protected Rigidbody2D Rigidbody; // ��ũ��Ʈ���� ��� ������������ protected�� ����, �ܺο��� ���� ���� �Ұ�(ĸ��ȭ)

    // ĳ���� �ø�
    [SerializeField] private SpriteRenderer CharacterFlip;

    // Move / �̵�����, �÷��̾� - wasd, �� - �ڵ�����
    protected Vector2 moveDirection = Vector2.zero;
    public Vector2 MoveDirection { get => moveDirection; } // �ܺ� ���� ���



    void Awake() // ������Ʈ ù ������ �ѹ� ȣ��, ������ �ʱ�ȭ �ܰ�
    {
        Rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
    }

    void Start() // ���۽� �ѹ� ȣ��, Awake() ������ ȣ��
    {
        
    }

    void Update() // �� �����Ӹ��� ȣ��, ���� X, �Ϲ� 
    {
        // �÷��̾� �̵� - > playerControl �ڽĿ���.. ������Ʈ�� �������̵尡 �ȵ�.��..
        KeyControl();
    }

    protected virtual void KeyControl()
    {
        // ���� X.. �÷��̾  / ������ؾ� �ڽĿ��� �������̵� ����
    }

    protected virtual void FixedUpdate() // ������ ������Ʈ, �� �����Ӹ��� ȣ��
    {
        Move(moveDirection);
    }

    // �̵� �ӵ�, ���� �̵�
    private void Move(Vector2 direction)
    {
        direction = direction * 7;
        Rigidbody.velocity = direction;
    }
}
