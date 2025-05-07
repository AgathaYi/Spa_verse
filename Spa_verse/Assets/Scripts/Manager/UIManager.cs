using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum UIState
{
    Home,
    Start,
    Game,
    GameOver,
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    // ����, ���ӿ���, ���ư���, ����, ü��, ����, �˾�, ��ư �� => ���� ���̴� �͵�
    [Header("Main Home")]
    [SerializeField] private GameObject homeUI;

    [Header("in BaseUI")]
    [SerializeField] private StartUI startUI;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private GameOverUI gameOverUI;

    private UIState currentState;

    void Awake()
    {
        //�̱��� �ʱ�ȭ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� ����!!
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϴ� ��� �ߺ� ����!!
        }

        // HomeUI ùȭ��ÿ���.
        bool firstHomeUI = PlayerPrefs.GetInt("notFirstHomeUI", 0) == 0;
        if (firstHomeUI)
        {
            ChangeState(UIState.Home);
            PlayerPrefs.SetInt("notFirstHomeUI", 1); // HomeUI�� ó���� �ƴ�
            PlayerPrefs.Save(); // �÷��̾� ����.
        }
        else
        {
            ChangeState(UIState.Game);
        }

            // in BaseUI �ʱ�ȭ
            startUI = GetComponentInChildren<StartUI>(true); //UI�Ŵ��� �ڽ� �Ʒ��θ� ã��
        if (startUI != null)
        {
            startUI.Init(this);
        }

        gameUI = GetComponentInChildren<GameUI>(true);
        if (gameUI != null)
        {
            gameUI.Init(this);
        }

        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        if (gameOverUI != null)
        {
            gameOverUI.Init(this);
        }


        ChangeState(UIState.Start);
    }

    // MiniGameZone
    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetRestart()
    {
        ChangeState(UIState.GameOver);
        SetActive(true);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
        SetActive(true);
    }

    public void SetGameOver(int score) //��������
    {
        // ���� ǥ��
        GameUI gameUI = FindObjectOfType<GameUI>();
        if (gameUI != null)
        {
            gameUI.UpScoreText(score);
        }
        else
        {
            Debug.LogError("GameUI not found");
        }
        // ���� ���� UI Ȱ��ȭ
        this.gameObject.SetActive(true);
    }

    //public void ChanPlayerHp(float currentHp, float maxHp)
    //{
    //    gameUI.UpdateHpSlider(currentHp / maxHp);
    //}

    public void ChangeState(UIState state)
    {
        // ������ UI ���� �ٸ�
        currentState = state;

        if (homeUI != null)
        {
            homeUI.SetActive(state == UIState.Home);
        }
        if (startUI != null)
        {
            startUI.SetActive(state);
        }
        if (gameUI != null)
        {
            gameUI.SetActive(state);
        }
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(state);
        }
    }



    // ������ Null �� �ٸ�.
    public void SetActive(bool isActive)
    {
        if (gameOverUI != null)
        {
            gameOverUI.gameObject.SetActive(isActive);
        }

        if (startUI != null)
        {
            startUI.gameObject.SetActive(isActive);
        }

        if (gameUI != null)
        {
            gameUI.gameObject.SetActive(isActive);
        }
    }
}