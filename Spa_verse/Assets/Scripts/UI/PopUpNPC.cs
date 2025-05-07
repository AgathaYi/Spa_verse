using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUpNPC : MonoBehaviour
{
    [Header("NPC condition")]
    [SerializeField] private Door doorCollider; // 문 열림 체크 (추후, 문열림 레벨 조건 추가 예정)
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

    private void Start() // 시작시
    {
        if (popUpUI != null && popUpAnimator != null)
        {
            popUpUI.SetActive(true); // Animator 초기화

            popUpAnimator.enabled = true;
            popUpAnimator.Rebind();
            popUpAnimator.Update(0);

            popUpUI.SetActive(false); // UI 비활성화
        }

        foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
        }

        npcCollider.enabled = false; // NPC 충돌체 비활성화
        checkSceneUI.SetActive(false);
    }

    private void Update() // 매프레임
    {
        // 존 오픈 여부 확인
        if (!zoneOpen && doorCollider != null && doorCollider.IsOpenDoor)
        {
            zoneOpen = true;

            // NPC 스프라이트 밝고 불투명하게 처리

            foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            }


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
            popUpUI.SetActive(true);
            popUpAnimator.SetBool("IsPopDown", false);
        }
    }

    //충돌영역이탈
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
