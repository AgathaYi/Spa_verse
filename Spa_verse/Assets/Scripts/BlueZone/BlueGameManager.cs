using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGameManager : MonoBehaviour
{
    public static BlueGameManager Instance { get; private set; } // 싱글톤 인스턴스
    public GameObject startUI; // 시작 UI

    public bool isGameStart = false; // 블루존 게임 시작 여부
    private int currentScore;
    public int currentCoin { get; private set; } // 현재 코인 수



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않음!!
            SceneManager.sceneLoaded += ReLoadScene; // 씬이 로드될 때마다 호출
        }
        else
        {
            Destroy(gameObject);
            return; // 이미 존재하는 경우 중복 방지!!
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
        isGameStart = false;

        if (startUI != null)
        {
            startUI.SetActive(true);
        }

        currentScore = 0;
        currentCoin = 0;
    }

    public void GameStart()
    {
        if (startUI != null)
        {
            startUI.SetActive(false);
        }

        Time.timeScale = 1f;
        isGameStart = true;
    }

    public void RestartGame()
    {
        SceneChange.Load(SceneManager.GetActiveScene().name, ReLoadScene);
        //startUI.SetActive(false);
    }

    void ReLoadScene(Scene scene, LoadSceneMode mode)
    {
        if (UIManager.Instance == null)
        {
            Debug.Log("UIManager is null");
        }

        StartUI startUI = GetComponentInChildren<StartUI>(true);
        GameUI gameUI = GetComponentInChildren<GameUI>(true);
        GameOverUI gameOverUI = GetComponentInChildren<GameOverUI>(true);

        currentScore = 0;
        UIManager.Instance.UpdateScoreUI(currentScore);
        UIManager.Instance.UpdateCoinUI(currentCoin);

        Time.timeScale = 1f;
        isGameStart = true;

        UIManager.Instance.SetPlayGame();
    }


    public void AddScore(int score)
    {
        currentScore += score;

        //GameUI 점수 업뎃
        UIManager.Instance.UpdateScoreUI(currentScore);
    }

    public void AddCoin(int coin)
    {
        currentCoin += coin;
        UIManager.Instance.UpdateCoinUI(currentCoin);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        // UIManager
        if (UIManager.Instance != null)
            UIManager.Instance.SetGameOver(currentScore);

        //코인 저장
        if (StatsManager.Instance != null)
            StatsManager.Instance.AddCoin(currentCoin);

        var gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
            gameOverUI.ShowCurrentScore(currentScore);
    }
}
