using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUI : BaseUI
{
    // ��ȣ�ۿ� ������, ������ �ߴ� UI���� ����ȯ
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
        uiManager.SetPlayGame(); // HomeUI �����
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