using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGameManager : MonoBehaviour
{
    public static BlueGameManager Instance { get; private set; } // 싱글톤 인스턴스
    public GameObject startUI;

    public bool isGameStart { get; private set; } // 게임 시작 여부

    private int currentScore;
    private int currentCoin;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
        isGameStart = false;
        startUI.SetActive(true);
        currentScore = 0;
        currentCoin = 0;
        startUI.SetActive(true);
    }

    public void GameStart()
    {
        startUI.SetActive(false);
        Time.timeScale = 1f;
        isGameStart = true;
    }

    public void AddScore (int score)
    {
        currentScore += score;
    }

    public void AddCoin(int coin)
    {
        currentCoin += coin;
    }

    public void CoinSavePlayer()
    {
        StatsManager.Instance.AddCoin(currentCoin);
        SceneChange.otherScene("MainScene");
    }

    public void RestartGame()
    {
        SceneChange.otherScene(SceneManager.GetActiveScene().name);
        GameStart();
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        UIManager.Instance.ChangeState(UIState.GameOver);
        UIManager.Instance.SetGameOver(currentScore);
        StatsManager.Instance.UpdateScoreUI(currentScore);

    }

}
