using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] private Door redDoor;

    //NPC
    [SerializeField] private SpriteRenderer npcSprite;
    [SerializeField] private BoxCollider2D npcCollider;
    [SerializeField] private GameObject npcSpeech;
    [SerializeField] private Animator popUpAnimator;

    private bool redZoneOpen = false;

    public GameObject RedZoneBtn;


    void Start() // ���۽�
    {
        if (npcSpeech != null)
        {
            popUpAnimator = npcSpeech.GetComponent<Animator>();
            npcSpeech.SetActive(true); // Animator
            popUpAnimator.Rebind();
            popUpAnimator.Update(0);

            npcSpeech.SetActive(false);
        }

        npcSprite = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        npcSprite.color = new Color(1, 1, 1, 0); // ����

        npcCollider = GetComponent<BoxCollider2D>();
    }

    void Update() // ��������
    {
        // ������ ���� ���� Ȯ��
        if (!redZoneOpen && redDoor != null && redDoor.IsOpenDoor)
        {
            redZoneOpen = true;
            npcSprite.color = new Color(1, 1, 1, 1); // ������
            npcCollider.enabled = true; // NPC �浹ü Ȱ��ȭ

            if (popUpAnimator != null)
            {
                popUpAnimator.enabled = true;
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

                if (popUpAnimator != null)
                {
                    popUpAnimator.SetBool("IsPopDown", false);
                }
            }
        }
    }

    //�浹������Ż
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
