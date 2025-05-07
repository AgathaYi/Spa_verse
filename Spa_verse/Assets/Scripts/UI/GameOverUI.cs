using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button closeBtn;

    public override UIState GetUIState => UIState.GameOver;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        restartBtn.onClick.AddListener(OnRestartButtonClick);
        closeBtn.onClick.AddListener(OnCloseButtonClick);
    }

    public void ShowCurrentScore(int score)
    {
        currentScoreTxt.text = score.ToString();
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

    public void OnCloseButtonClick()
    {
         SceneManager.LoadScene("MainScene");
    }

}
