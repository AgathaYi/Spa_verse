using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGameManager : MonoBehaviour
{
    GameManager gameManager;
    static BlueGameManager blueGameManager;
    public static BlueGameManager Instance { get => blueGameManager; }

    public BluePlayer player { get; private set; } // 블루존 플레이어

    public GameObject startUI;
    public bool isGameStart = false;
    private int currentScore = 0; // 현재 점수

    private void Awake()
    {
        blueGameManager = this;
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        isGameStart = false;
        startUI.SetActive(true);
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        isGameStart = true;
        startUI.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore (int score)
    {
        currentScore += score;
        
        gameManager.StatsManager.AddScore(score);
        gameManager.StatsManager.AddCoin(score); // 1점 = 1코인 지급 예정
        gameManager.UIManager.UpdateScoreUI(currentScore);
        gameManager.UIManager.UpdateCoinUI(currentScore);
    }

    public void GameOver()
    {
        Debug.Log("게임 오버");
    }

}
