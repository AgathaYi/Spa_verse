using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUI : BaseUI
{
    // 상호작용 수락후, 다음에 뜨는 UI에서 씬전환
    [SerializeField] private Button startBtn;
    [SerializeField] private Button exitBtn;

    public override UIState GetUIState => UIState.Home;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        Time.timeScale = 0f; // 게임 정지

        startBtn.onClick.AddListener(OnClickStartBtn);
        exitBtn.onClick.AddListener(OnClickExitBtn);
    }

    public void OnClickStartBtn()
    {
        Time.timeScale = 1f; // 게임 시작
        uiManager.SetPlayGame(); // HomeUI 사라짐

        // 메인씬 게임매니져
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameStart(); // 게임 시작
        }
    }

    public void OnClickExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}