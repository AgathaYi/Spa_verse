using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZoneBtn : MonoBehaviour
{
    private string targetSceneName;

    [Header("NPC_Popup")]
    public GameObject npcPopUpUI;
    public Button acceptBtn;

    [Header("SceneChange")]
    public GameObject checkSceneChangeUI;
    public Button yesBtn;
    public Button noBtn;

    private void Awake()
    {
        targetSceneName = gameObject.name;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ZonePopUpNPC -> ZoneBtn
            npcPopUpUI.SetActive(false); // �˾� UI ��Ȱ��ȭ
            checkSceneChangeUI.SetActive(false); // �� ��ȯ UI ��Ȱ��ȭ
        }
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        // �� ��ȯ��, �˾� UI ��Ȱ��ȭ
        GameManager.Instance.ResetScene(scene.name);
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    public void OnClickAcceptBtn()
    {
        if (npcPopUpUI != null)
        {
            npcPopUpUI.SetActive(false); // �˾� UI ��Ȱ��ȭ
            checkSceneChangeUI.SetActive(true); // �� ��ȯ UI Ȱ��ȭ
        }
    }

    public void OnClickCancleBtn()
    {
        checkSceneChangeUI.SetActive(false);
        npcPopUpUI.SetActive(false);
    }


    public void OnClickSceneChangeBtn()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        SceneManager.LoadScene(targetSceneName); // ����Ƽ���� �����ϴ� �� ��ȯ �޼ҵ�
    }

}