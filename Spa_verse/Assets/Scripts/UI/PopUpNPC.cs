using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUpNPC : MonoBehaviour
{
    [Header("NPC condition")]
    [SerializeField] private Door doorCollider; // �� ���� üũ (����, ������ ���� ���� �߰� ����)
    [SerializeField] private SpriteRenderer npcSprite;
    [SerializeField] private BoxCollider2D npcCollider;

    [Header("Interaction PopUp")]
    [SerializeField] private GameObject popUpUI;
    [SerializeField] private Animator popUpAnimator;
    [SerializeField] private Button acceptBtn;

    [Header("Change Scene Y/N")]
    [SerializeField] private GameObject checkSceneUI;
    [SerializeField] private Button yesBtn;
    [SerializeField] private Button noBtn;

    private bool zoneOpen = false;
    private string targetSceneName;

    private void Awake()
    {
        targetSceneName = gameObject.name;

        acceptBtn.onClick.AddListener(OnAcceptBtn);
        yesBtn.onClick.AddListener(OnYesBtn);
        noBtn.onClick.AddListener(OnNoBtn);
    }

    private void Start() // ���۽�
    {
        if (popUpUI != null && popUpAnimator != null)
        {
            popUpUI.SetActive(true); // Animator �ʱ�ȭ

            popUpAnimator.enabled = true;
            popUpAnimator.Rebind();
            popUpAnimator.Update(0);

            popUpUI.SetActive(false); // UI ��Ȱ��ȭ
        }

        foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
        }

        npcCollider.enabled = false; // NPC �浹ü ��Ȱ��ȭ
        checkSceneUI.SetActive(false);
    }

    private void Update() // ��������
    {
        // �� ���� ���� Ȯ��
        if (!zoneOpen && doorCollider != null && doorCollider.IsOpenDoor)
        {
            zoneOpen = true;

            // NPC ��������Ʈ ��� �������ϰ� ó��

            foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            }


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
            popUpUI.SetActive(true);
            popUpAnimator.SetBool("IsPopDown", false);
        }
    }

    //�浹������Ż
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (zoneOpen && collider.CompareTag("Player") && popUpUI.activeSelf)
        {
            popUpAnimator.SetBool("IsPopDown", true);
        }

    }

    public void OnAcceptBtn()
    {
        popUpUI.SetActive(false);
        checkSceneUI.SetActive(true);
    }

    public void OnYesBtn()
    {
        SceneManager.LoadScene(targetSceneName);
    }

    public void OnNoBtn()
    {
        checkSceneUI.SetActive(false);
        popUpUI.SetActive(false);
    }

    public void OnPopDown()
    {
        if (popUpUI != null)
        {
            popUpUI.SetActive(false);
        }
    }
}
