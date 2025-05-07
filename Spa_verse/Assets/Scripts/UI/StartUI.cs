using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button closeButton; // 메인씬으로

    public override UIState GetUIState => UIState.Start;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        Time.timeScale = 0f; // 게임 정지

        startButton.onClick.AddListener(OnStartButtonClick);
        closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    public void OnStartButtonClick()
    {
        uiManager.SetPlayGame();
        gameObject.SetActive(false);
        Time.timeScale = 1f;

        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            GameManager.Instance.GameStart();
        }
        else if (currentSceneName == "BlueZone")
        {
            BlueGameManager.Instance.GameStart();
        }
        else if (currentSceneName == "RedZone")
        {
            RedGameManager.Instance.GameStart();
        }
        //else if (currentSceneName == "GreenZone")
        //{
        //    GreenGameManager.Instance.GameStart();
        //}
        //else if (currentSceneName == "YellowZone")
        //{
        //    YellowGameManager.Instance.GameStart();
        //}
    }

    public void OnCloseButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "MainScene")
        {
            SceneChange.otherScene("MainScene");
        }
        else
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
