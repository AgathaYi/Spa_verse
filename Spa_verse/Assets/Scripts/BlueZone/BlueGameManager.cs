using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGameManager : MonoBehaviour
{
    static BlueGameManager blueGameManager;
    public static BlueGameManager Instance { get => blueGameManager; }

    public BluePlayer player { get; private set; } // ����� �÷��̾�

    public GameObject startUI;
    public bool isGameStart = false;
    private int currentScore = 0; // ���� ����

    private void Awake()
    {
        blueGameManager = this;
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
        
        GameManager.Instance.ScoreManager.AddScore(score);
        GameManager.Instance.ScoreManager.AddCoin(score); // 1�� = 1���� ���� ����
    }

    public void GameOver()
    {
        Debug.Log("���� ����");
    }

}
