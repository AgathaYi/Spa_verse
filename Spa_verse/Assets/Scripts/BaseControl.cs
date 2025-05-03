using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour // 생명체들의 부모
{
    // 중력, 충돌체, 이동, 점프력, 공격력, 체력, 사망여부, 공격여부, 행동여부 ...
    // Rigidbody2D, Collider2D, Animator, SpriteRenderer, AudioSource, Transform, GameObject
    // private : 소문자시작.

    protected Rigidbody2D Rigidbody; // 스크립트에서 사용 가능해지도록 protected로 설정, 외부에서 직접 접근 불가(캡슐화)

    // 캐릭터 플립
    [SerializeField] private SpriteRenderer CharacterFlip;

    // Move / 이동방향, 플레이어 - wasd, 적 - 자동랜덤
    protected Vector2 moveDirection = Vector2.zero;
    public Vector2 MoveDirection { get => moveDirection; } // 외부 접근 경로



    void Awake() // 오브젝트 첫 생성시 한번 호출, 안전한 초기화 단계
    {
        Rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    void Start() // 시작시 한번 호출, Awake() 다음에 호출
    {
        
    }

    void Update() // 매 프레임마다 호출, 물리 X, 일반 
    {
        // 플레이어 이동 - > playerControl 자식에서.. 업데이트가 오버라이드가 안됨.음..
        KeyControl();
    }

    protected virtual void KeyControl()
    {
        // 적은 X.. 플레이어만  / 버츄얼해야 자식에서 오버라이드 가능
    }

    protected virtual void FixedUpdate() // 물리적 업데이트, 매 프레임마다 호출
    {
        Move(moveDirection);
    }

    // 이동 속도, 실제 이동
    private void Move(Vector2 direction)
    {
        direction = direction * 7;
        Rigidbody.velocity = direction;
    }
}
