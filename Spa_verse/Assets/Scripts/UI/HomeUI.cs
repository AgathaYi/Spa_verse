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
        startBtn.onClick.AddListener(OnClickStartBtn);
        exitBtn.onClick.AddListener(OnClickExitBtn);
    }

    public void OnClickStartBtn()
    {
        uiManager.SetPlayGame(); // HomeUI 사라짐
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