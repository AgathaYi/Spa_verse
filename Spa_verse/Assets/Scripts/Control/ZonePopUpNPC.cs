using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZonePopUpNPC : MonoBehaviour
{
    [SerializeField] private Door doorCollider;

    [Header("NPC")]
    [SerializeField] private SpriteRenderer npcSprite;
    [SerializeField] private BoxCollider2D npcCollider;

    [Header("PopUp")]
    [SerializeField] private GameObject PopUpUI;
    [SerializeField] private Animator popUpAnimator;

    private bool zoneOpen = false;

    public GameObject ZoneBtn;


    void Start() // 시작시
    {
        if (PopUpUI != null)
        {
            popUpAnimator = PopUpUI.GetComponent<Animator>();
            PopUpUI.SetActive(true); // Animator 초기화
            popUpAnimator.enabled = true;
            popUpAnimator.Rebind();
            popUpAnimator.Update(0);
            PopUpUI.SetActive(false); // UI 비활성화
        }

        //npcSprite = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        //npcSprite.color = new Color(1, 1, 1, 0); // 투명

        SpriteRenderer[] npcSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in npcSprites)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0); // 투명
        }

        npcCollider = GetComponent<BoxCollider2D>();
    }

    void Update() // 매프레임
    {
        // 존 오픈 여부 확인
        if (!zoneOpen && doorCollider != null && doorCollider.IsOpenDoor)
        {
            zoneOpen = true;
            npcSprite.color = new Color(1, 1, 1, 1); // 불투명
            npcCollider.enabled = true; // NPC 충돌체 활성화

            if (popUpAnimator != null)
            {
                popUpAnimator.enabled = true;
            }
        }
    }

    //충돌영역진입
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (zoneOpen && collider.CompareTag("Player"))
        {
            PopUpUI.SetActive(true);
            popUpAnimator.SetBool("IsPopDown", false);
        }
    }

    //충돌영역이탈
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (zoneOpen && collider.CompareTag("Player") && PopUpUI.activeSelf)
        {
            popUpAnimator.SetBool("IsPopDown", true);
        }

    }

    public void OnPopDown()
    {
        if (PopUpUI != null)
        {
            PopUpUI.SetActive(false);
        }
    }
}
