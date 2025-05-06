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
            npcPopUpUI.SetActive(false); // 팝업 UI 비활성화
            checkSceneChangeUI.SetActive(false); // 씬 전환 UI 비활성화
        }
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        // 씬 전환후, 팝업 UI 비활성화
        GameManager.Instance.ResetScene(scene.name);
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    public void OnClickAcceptBtn()
    {
        if (npcPopUpUI != null)
        {
            npcPopUpUI.SetActive(false); // 팝업 UI 비활성화
            checkSceneChangeUI.SetActive(true); // 씬 전환 UI 활성화
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
        SceneManager.LoadScene(targetSceneName); // 유니티에서 제공하는 씬 전환 메소드
    }

}