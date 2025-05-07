using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button closeButton; // 메인씬으로
    [SerializeField] private Button exitBtn; // 게임종료: 메인씬만 활성화

    public override UIState GetUIState => UIState.Start;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        startButton.onClick.AddListener(OnStartButtonClick);
        closeButton.onClick.AddListener(OnCloseButtonClick);
        exitBtn.onClick.AddListener(OnExitBtnClick);
    }

    public void OnStartButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            uiManager.ChangeState(UIState.Game);
        }
        else if (currentSceneName == "BlueZone")
        {
            uiManager.SetPlayGame();
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

    private void OnCloseButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "MainScene")
        {
            SceneChange.otherScene("MainScene");
        }
    }

    //버튼 클릭시, 게임 종료 및 유니티 에디터만 종료
    public void OnExitBtnClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "MainScene")
        {
            Debug.Log("해당 씬 Exit버튼 비활성화");
            return;
        }

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
