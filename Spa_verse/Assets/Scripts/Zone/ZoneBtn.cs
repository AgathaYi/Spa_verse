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
            popUpUI.SetActive(true); // �˾� UI Ȱ��ȭ
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUpUI.SetActive(false); // �˾� UI ��Ȱ��ȭ
        }
    }

    public void OnClickZoneBtn()
    {
        SceneManager.LoadScene(targetSceneName); // ����Ƽ���� �����ϴ� �� ��ȯ �޼ҵ�
    }
}