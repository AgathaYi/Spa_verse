using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneBtn : MonoBehaviour
{
    private string targetSceneName;

    private void Awake()
    {
        targetSceneName = gameObject.name;
    }

    public void OnClickZoneBtn()
    {
        SceneManager.LoadScene(targetSceneName); // ����Ƽ���� �����ϴ� �� ��ȯ �޼ҵ�
    }
}