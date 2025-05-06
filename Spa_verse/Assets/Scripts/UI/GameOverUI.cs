using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button closeButton;

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
        if (currentSceneName == "BlueZone")
        {
            if (uiManager != null)
            {
                uiManager.SetPlayGame();
                BlueGameManager.Instance.GameStart();
            }
            else
            {
                Debug.LogError("UIManager .null");
            }
        }
        //else if (currentSceneName == "RedZone")
        //{
        //    RedGameManager.Instance.GameStart();
        //}
    }

    public void OnExitButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            return;
        }

        ZoneBtn zoneBtn = GameManager.Instance.ZoneBtn;
        if (zoneBtn != null)
        {
            zoneBtn.OnClickCancleBtn();
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }

    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}
