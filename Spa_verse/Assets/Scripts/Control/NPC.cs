using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    //NPC
    [SerializeField] private SpriteRenderer npcSprite;
    [SerializeField] private BoxCollider2D npcCollider;
    [SerializeField] private GameObject npcSpeech;
    [SerializeField] private Animator popUpAnimator;

    private bool redZoneOpen = false;

    public GameObject RedZoneBtn;

    public bool RedZoneOpen
    {
        get { return redZoneOpen; }
        set { redZoneOpen = value; }
    }

    void Start() // 시작시
    {
        if (npcSpeech != null)
        {
            popUpAnimator = npcSpeech.GetComponent<Animator>();
            npcSpeech.SetActive(true);
            popUpAnimator.Rebind();
            popUpAnimator.Update(0);
        }

        npcSprite = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        npcSprite.color = new Color(1, 1, 1, 0); // 투명

        npcCollider = GetComponent<BoxCollider2D>();
    }

    void Update() // 매프레임
    {
        // 레드존 오픈 여부 확인
        if (!redZoneOpen)
        {
            redZoneOpen = true;
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
        if (redZoneOpen && collider.CompareTag("Player"))
        {
            if (npcSpeech != null)
            {
                npcSpeech.SetActive(true);

                if (popUpAnimator != null)
                {
                    popUpAnimator.SetBool("IsPopDown", false);
                }
            }
        }
    }

    //충돌영역이탈
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (redZoneOpen && collider.CompareTag("Player"))
        {
            if (npcSpeech != null && npcSpeech.activeSelf && popUpAnimator != null)
            {
                popUpAnimator.SetBool("IsPopDown", true);
            }
        }
        
    }

    public void OnPopDown()
    {
        if (npcSpeech != null)
        {
            npcSpeech.SetActive(false);
        }
    }
}
