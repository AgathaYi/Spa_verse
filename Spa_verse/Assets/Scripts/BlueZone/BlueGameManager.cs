using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGameManager : MonoBehaviour
{
    public static BlueGameManager Instance { get; private set; } // 싱글톤 인스턴스
    public int currentScore { get; private set; } // 현재 점수
    public int currentCoin { get; private set; } // 현재 코인


    [SerializeField] private GameObject startUI;
    public bool isGameStart = false;



    private void Awake()
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

    private void Start()
    {
        Time.timeScale = 0f;
        isGameStart = false;
        startUI.SetActive(true);
        currentScore = 0;
        currentCoin = 0;
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        isGameStart = true;
        startUI.SetActive(false);
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
        GameManager.Instance.StatsManager.AddCoin(currentCoin);
        SceneManager.LoadScene("MainScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        Debug.Log("게임 오버");
        // 게임 over ui 별도관리
    }

}
