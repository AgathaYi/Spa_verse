using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour // ����ü���� �θ�
{
    // �߷�, �浹ü, �̵�, ������, ���ݷ�, ü��, �������, ���ݿ���, �ൿ���� ...
    // Rigidbody2D, Collider2D, Animator, SpriteRenderer, AudioSource, Transform, GameObject
    // private : �ҹ��ڽ���.

    protected Rigidbody2D Rigidbody; // ��ũ��Ʈ���� ��� ������������ protected�� ����, �ܺο��� ���� ���� �Ұ�(ĸ��ȭ)
    



    void Awake() // ������Ʈ ù ������ �ѹ� ȣ��, ������ �ʱ�ȭ �ܰ�
    {
        Rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
