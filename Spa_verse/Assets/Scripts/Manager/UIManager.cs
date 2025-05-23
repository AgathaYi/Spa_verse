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
    [Header("First HomeUI")]
    [SerializeField] private GameObject homeUI;

    [Header("in BaseUI")]
    [SerializeField] private StartUI startUI;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private GameOverUI gameOverUI;

    [Header("MiniGameZone Stats")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinText;

    void Awake()
    {
        Instance = this;

        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            PlayerPrefs.DeleteKey("notFirstHomeUI");
        }


        // in BaseUI 초기화
        if (startUI == null)
            startUI = GetComponentInChildren<StartUI>(true); //UI매니져 자식 아래로만 찾기
        if (gameUI == null)
            gameUI = GetComponentInChildren<GameUI>(true);
        if (gameOverUI == null)
            gameOverUI = GetComponentInChildren<GameOverUI>(true);


        if (startUI != null)
            startUI.Init(this);
        if (gameUI != null)
            gameUI.Init(this);
        if (gameOverUI != null)
            gameOverUI.Init(this);


        // HomeUI 초기화!!! 
        if (currentSceneName == "MainScene")
        {
            if (homeUI != null)
            {
                var varHomeUI = homeUI.GetComponent<HomeUI>();
                if (varHomeUI != null)
                {
                    varHomeUI.Init(this);
                }
                else
                {
                    Debug.LogError("HomeUI 에러-UIManager Awake");
                }
            }

            ChangeState(UIState.Home);
        }
        else
        {
            ChangeState(UIState.Start);
        }

        if (StatsManager.Instance != null)
        {
            UpdateScoreUI(StatsManager.Instance.totalScore);
            UpdateCoinUI(StatsManager.Instance.totalCoin);
        }
    }

    public void ChangeState(UIState state)
    {
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

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    // MiniGameZone
    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void UpdateCoinUI(int coin)
    {
        if (coinText != null)
        {
            coinText.text = coin.ToString();
        }
    }

    public void SetGameOver(int score) //현재점수
    {
        ChangeState(UIState.GameOver);
        // 점수 표시
        if (gameOverUI != null)
        {
            gameOverUI.ShowCurrentScore(score);
        }
        else
        {
            Debug.LogError("GameUI 없음");
        }
    }

    //public void SetPlayerHp(float currentHp, float maxHp)
    //{
    //    gameUI.UpdateHpSlider(currentHp / maxHp);
    //}

}