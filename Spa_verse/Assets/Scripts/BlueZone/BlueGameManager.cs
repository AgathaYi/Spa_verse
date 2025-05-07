using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGameManager : MonoBehaviour
{
    public static BlueGameManager Instance { get; private set; } // �̱��� �ν��Ͻ�
    public GameObject startUI; // ���� UI

    public bool isGameStart = false; // ����� ���� ���� ����
    private int currentScore;
    public int currentCoin { get; private set; } // ���� ���� ��



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� ����!!
        }
        else
        {
            Destroy(gameObject);
            return; // �̹� �����ϴ� ��� �ߺ� ����!!
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
    }

    private void ReLoadScene(Scene scene, LoadSceneMode mode)
    {
        currentScore = 0;
        UIManager.Instance.UpdateScoreUI(currentScore);
        UIManager.Instance.UpdateCoinUI(currentCoin);

        Time.timeScale = 1f;
        isGameStart = true;
    }


    public void AddScore(int score)
    {
        currentScore += score;

        //GameUI ���� ����
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

        //���� ������ (over, clear ����) ���� ����

        UIManager.Instance.SetGameOver(currentScore);
        StatsManager.Instance.AddCoin(currentCoin);
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        gameOverUI.ShowCurrentScore(currentScore);

    }
}
