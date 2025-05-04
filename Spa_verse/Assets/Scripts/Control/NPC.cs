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
        npcSprite.color = new Color(1, 1, 1, 0); // ����

        npcCollider = GetComponent<BoxCollider2D>();

        if (RedZoneBtn != null)
        {
            RedZoneBtn.SetActive(false); // ������ ��ư ��Ȱ��ȭ
        }
    }

    void Update()
    {
        // ������ ���� ���� Ȯ��
        if (!redZoneOpen)
        {
            redZoneOpen = true;
            npcSprite.color = new Color(1, 1, 1, 1); // ������
            npcCollider.enabled = true; // NPC �浹ü Ȱ��ȭ
            if (speechAnimator != null)
            {
                speechAnimator.enabled = true;
            }
        }
    }

    //�浹��������
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

    //�浹������Ż
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
