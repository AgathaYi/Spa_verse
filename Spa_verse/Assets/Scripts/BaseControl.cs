using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour // 생명체들의 부모
{
    // 중력, 충돌체, 이동, 점프력, 공격력, 체력, 사망여부, 공격여부, 행동여부 ...
    // Rigidbody2D, Collider2D, Animator, SpriteRenderer, AudioSource, Transform, GameObject
    // private : 소문자시작.

    protected Rigidbody2D Rigidbody; // 스크립트에서 사용 가능해지도록 protected로 설정, 외부에서 직접 접근 불가(캡슐화)
    



    void Awake() // 오브젝트 첫 생성시 한번 호출, 안전한 초기화 단계
    {
        Rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
