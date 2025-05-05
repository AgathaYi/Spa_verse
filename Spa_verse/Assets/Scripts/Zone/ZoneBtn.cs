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
        SceneManager.LoadScene(targetSceneName); // 유니티에서 제공하는 씬 전환 메소드
    }
}