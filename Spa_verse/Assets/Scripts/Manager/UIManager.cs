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

    // 시작, 게임오버, 돌아가기, 점수, 체력, 코인, 팝업, 버튼 등 => 눈에 보이는 것들
    [Header("Main Home")]
    [SerializeField] private GameObject homeUI;

    [Header("in BaseUI")]
    [SerializeField] private StartUI startUI;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private GameOverUI gameOverUI;

    private UIState currentState;

    void Awake()
    {
        //싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않음!!
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 경우 중복 방지!!
        }

        // HomeUI 첫화면시에만.
        bool firstHomeUI = PlayerPrefs.GetInt("notFirstHomeUI", 0) == 0;
        if (firstHomeUI)
        {
            ChangeState(UIState.Home);
            PlayerPrefs.SetInt("notFirstHomeUI", 1); // HomeUI가 처음이 아님
            PlayerPrefs.Save(); // 플레이어 저장.
        }
        else
        {
            ChangeState(UIState.Game);
        }

            // in BaseUI 초기화
            startUI = GetComponentInChildren<StartUI>(true); //UI매니져 자식 아래로만 찾기
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

    public void SetGameOver(int score) //현재점수
    {
        // 점수 표시
        GameUI gameUI = FindObjectOfType<GameUI>();
        if (gameUI != null)
        {
            gameUI.UpScoreText(score);
        }
        else
        {
            Debug.LogError("GameUI not found");
        }
        // 게임 오버 UI 활성화
        this.gameObject.SetActive(true);
    }

    //public void ChanPlayerHp(float currentHp, float maxHp)
    //{
    //    gameUI.UpdateHpSlider(currentHp / maxHp);
    //}

    public void ChangeState(UIState state)
    {
        // 씬별로 UI 상태 다름
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



    // 씬별로 Null 값 다름.
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