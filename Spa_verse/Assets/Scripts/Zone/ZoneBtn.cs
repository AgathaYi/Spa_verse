using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZoneBtn : MonoBehaviour
{
    private string targetSceneName;
    public GameObject popUpUI;

    private void Awake()
    {
        targetSceneName = gameObject.name;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUpUI.SetActive(true); // 팝업 UI 활성화
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUpUI.SetActive(false); // 팝업 UI 비활성화
        }
    }

    public void OnClickZoneBtn()
    {
        SceneManager.LoadScene(targetSceneName); // 유니티에서 제공하는 씬 전환 메소드
    }
}