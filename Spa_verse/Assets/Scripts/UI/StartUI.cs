using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        startButton.onClick.AddListener(OnStartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    public void OnStartButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            GameManager.Instance.GameStart();
        }
        else if (currentSceneName == "BlueZone")
        {
            BlueGameManager.Instance.GameStart();
        }
        //else if (currentSceneName == "RedZone")
        //{
        //    RedGameManager.Instance.GameStart();
        //}
        //else if (currentSceneName == "GreenZone")
        //{
        //    GreenGameManager.Instance.GameStart();
        //}
        //else if (currentSceneName == "YellowZone")
        //{
        //    YellowGameManager.Instance.GameStart();
        //}
    }

    public void OnExitButtonClick()
    {
        ZoneBtn zoneBtn = GameManager.Instance.ZoneBtn;
        if (zoneBtn != null)
        {
            zoneBtn.OnClickCancleBtn();
        }
        else
        {
            Application.Quit();
        }
    }

    protected override UIState GetUIState()
    {
        return UIState.Start;
    }
}
