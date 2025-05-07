using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button closeButton;

    public override UIState GetUIState => UIState.GameOver;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        restartButton.onClick.AddListener(OnRestartButtonClick);
        closeButton.onClick.AddListener(OnExitButtonClick);
    }
    public void OnRestartButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            this.gameObject.SetActive(false);
            if (uiManager != null)
            {
                uiManager.SetPlayGame();
            }
            return;
        }

        // 메인씬이 아닐때, 게임 시작
        if (currentSceneName != "MainScene")
        {
            if (uiManager != null)
            {
                uiManager.SetPlayGame();
                BlueGameManager.Instance.RestartGame();
            }
            else
            {
                Debug.LogError("UIManager .null");
            }
        }
    }

    public void OnExitButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            this.gameObject.SetActive(false);
            if (uiManager != null)
            {
                uiManager.SetPlayGame();
            }
            return;
        }

        // 메인씬이 아닐때, 게임 시작
        if (currentSceneName != "MainScene")
        {
            BlueGameManager.Instance.CoinSavePlayer();
            SceneManager.LoadScene("MainScene");
        }
    }

}
