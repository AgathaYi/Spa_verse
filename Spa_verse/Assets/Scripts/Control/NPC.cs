using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //NPC
    [SerializeField] private SpriteRenderer npcSprite;
    [SerializeField] private BoxCollider2D npcCollider;
    [SerializeField] private GameObject npcSpeech;
    [SerializeField] private Animator speechAnimator;

    private bool redZoneOpen = false;

    public GameObject RedZoneBtn;

    public bool RedZoneOpen
    {
        get { return redZoneOpen; }
        set { redZoneOpen = value; }
    }

    void Start()
    {
        if (npcSpeech != null)
        {
            speechAnimator = npcSpeech.GetComponent<Animator>();
            npcSpeech.SetActive(false);
        }

        npcSprite = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        npcSprite.color = new Color(1, 1, 1, 0); // 투명

        npcCollider = GetComponent<BoxCollider2D>();

        if (RedZoneBtn != null)
        {
            RedZoneBtn.SetActive(false); // 레드존 버튼 비활성화
        }
    }

    void Update()
    {
        // 레드존 오픈 여부 확인
        if (!redZoneOpen)
        {
            redZoneOpen = true;
            npcSprite.color = new Color(1, 1, 1, 1); // 불투명
            npcCollider.enabled = true; // NPC 충돌체 활성화
            if (speechAnimator != null)
            {
                speechAnimator.enabled = true;
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
                if (speechAnimator != null)
                {
                    speechAnimator.Play("Talk", 0, 0);
                }
            }
        }
    }

    //충돌영역이탈
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (npcSpeech != null && npcSpeech.activeSelf && speechAnimator != null)
            {
                speechAnimator.Play("TalkClean", 0, 0);
            }
        }
        
    }

    public void OnTalkClean()
    {
        if (npcSpeech != null)
        {
            npcSpeech.SetActive(false);
        }
    }
}
