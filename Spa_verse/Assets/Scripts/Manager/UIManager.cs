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
    [Header("First HomeUI")]
    [SerializeField] private GameObject homeUI;

    [Header("in BaseUI")]
    [SerializeField] private StartUI startUI;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private GameOverUI gameOverUI;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI scoreText; // ����
    [SerializeField] private TextMeshProUGUI coinText; // ����

    void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            PlayerPrefs.DeleteKey("notFirstHomeUI");
        }

        //�̱��� �ʱ�ȭ
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϴ� ��� �ߺ� ����
            return;
        }

        // in BaseUI �ʱ�ȭ
        startUI = GetComponentInChildren<StartUI>(true); //UI�Ŵ��� �ڽ� �Ʒ��θ� ã��
        gameUI = GetComponentInChildren<GameUI>(true);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);

        if (startUI != null)
        {
            startUI.Init(this);
        }

        if (gameUI != null)
        {
            gameUI.Init(this);
        }

        if (gameOverUI != null)
        {
            gameOverUI.Init(this);
        }

        // HomeUI �ʱ�ȭ!!! 
        if (homeUI != null)
        {
            var varHomeUI = homeUI.GetComponent<HomeUI>();
            if (varHomeUI != null)
            {
                varHomeUI.Init(this);
            }
            else
            {
                Debug.LogError("HomeUI ����-UIManager Awake");
            }
        }
        else
        {
            Debug.LogError("������Ʈ �ν�����â Ȯ��");
        }

        // HomeUI ùȭ���
        bool firstHomeUI = PlayerPrefs.GetInt("notFirstHomeUI", 0) == 0;
        ChangeState(firstHomeUI ? UIState.Home : UIState.Start); // ó�� HomeUI�϶��� HomeUI Ȱ��ȭ
        if (firstHomeUI)
        {
            PlayerPrefs.SetInt("notFirstHomeUI", 1); // HomeUI�� ó���� �ƴ�
            PlayerPrefs.Save(); // �÷��̾� ����.
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

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver(int score) //��������
    {
        ChangeState(UIState.GameOver);
        // ���� ǥ��
        GameUI gameUI = FindObjectOfType<GameUI>();
        if (gameUI != null)
        {
            gameUI.UpScoreText(score);
        }
        else
        {
            Debug.LogError("GameUI ����");
        }
    }

    //public void SetPlayerHp(float currentHp, float maxHp)
    //{
    //    gameUI.UpdateHpSlider(currentHp / maxHp);
    //}

}