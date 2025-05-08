using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGameManager : MonoBehaviour
{
    public static BlueGameManager Instance { get; private set; } // �̱��� �ν��Ͻ�
    public GameObject startUI; // ���� UI

    public bool isGameStart = false; // ����� ���� ���� ����
    public bool isRestart = false; // ����� ����
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
        isRestart = true;
        SceneManager.sceneLoaded += ReLoadScene; // �� ��ε��ҋ�, �ش� �޼��� ȣ��
        SceneChange.Load(SceneManager.GetActiveScene().name, ReLoadScene);
    }

    // ���� �ʱ�ȭ, �ð�����, GameUI ����
    void ReLoadScene(Scene scene, LoadSceneMode mode)
    {
        if (!isGameStart) //������ ���۾��ϸ�, ����
        {
            return;
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

        // UIManager
        if (UIManager.Instance != null)
            UIManager.Instance.SetGameOver(currentScore);

        //���� ����
        if (StatsManager.Instance != null)
            StatsManager.Instance.AddCoin(currentCoin);

        var gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
            gameOverUI.ShowCurrentScore(currentScore);
    }
}
