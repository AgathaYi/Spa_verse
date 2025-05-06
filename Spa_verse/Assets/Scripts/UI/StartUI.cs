using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button exitBtn;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        startButton.onClick.AddListener(OnStartButtonClick);

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(OnCloseButtonClick);

        }

        if (exitBtn != null)
        {
            exitBtn.onClick.AddListener(OnExitBtnClick);
        }
    }

    public void OnStartButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            this.gameObject.SetActive(false);
            if (GameManager.Instance.UIManager != null)
            {
                GameManager.Instance.UIManager.SetPlayGame();
            }
            return;
        }

        // ���ξ��� �ƴҶ�, ���� ����
        if (currentSceneName == "BlueZone")
        {
            if (GameManager.Instance.UIManager != null)
            {
                GameManager.Instance.UIManager.SetPlayGame();
                BlueGameManager.Instance.GameStart();
            }
            else
            {
                Debug.LogError("UIManager .. �ФФ� null");
            }
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

    public void OnCloseButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "MainScene")
        {
            Debug.Log("�ش� �� colse��ư ��Ȱ��ȭ");
            return;
        }

        // ���ξ����� �̵�
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

    //��ư Ŭ����, ���� ���� �� ����Ƽ �����͸� ����
    public void OnExitBtnClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "MainScene")
        {
            Debug.Log("�ش� �� Exit��ư ��Ȱ��ȭ");
            return;
        }

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
