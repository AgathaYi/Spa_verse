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


    void Start() // ���۽�
    {
        if (PopUpUI != null)
        {
            popUpAnimator = PopUpUI.GetComponent<Animator>();
            PopUpUI.SetActive(true); // Animator �ʱ�ȭ
            popUpAnimator.enabled = true;
            popUpAnimator.Rebind();
            popUpAnimator.Update(0);
            PopUpUI.SetActive(false); // UI ��Ȱ��ȭ
        }

        //npcSprite = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        //npcSprite.color = new Color(1, 1, 1, 0); // ����

        SpriteRenderer[] npcSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in npcSprites)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0); // ����
        }

        npcCollider = GetComponent<BoxCollider2D>();
    }

    void Update() // ��������
    {
        // �� ���� ���� Ȯ��
        if (!zoneOpen && doorCollider != null && doorCollider.IsOpenDoor)
        {
            zoneOpen = true;
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
        if (zoneOpen && collider.CompareTag("Player"))
        {
            PopUpUI.SetActive(true);
            popUpAnimator.SetBool("IsPopDown", false);
        }
    }

    //�浹������Ż
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
