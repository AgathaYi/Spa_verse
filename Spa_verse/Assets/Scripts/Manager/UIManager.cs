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

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI scoreText; // 점수
    [SerializeField] private TextMeshProUGUI coinText; // 코인

    void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            PlayerPrefs.DeleteKey("notFirstHomeUI");
        }

        //싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 경우 중복 방지
            return;
        }

        // in BaseUI 초기화
        startUI = GetComponentInChildren<StartUI>(true); //UI매니져 자식 아래로만 찾기
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

        // HomeUI 초기화!!! 
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
        else
        {
            Debug.LogError("오브젝트 인스펙터창 확인");
        }

        // HomeUI 첫화면시
        bool firstHomeUI = PlayerPrefs.GetInt("notFirstHomeUI", 0) == 0;
        ChangeState(firstHomeUI ? UIState.Home : UIState.Start); // 처음 HomeUI일때만 HomeUI 활성화
        if (firstHomeUI)
        {
            PlayerPrefs.SetInt("notFirstHomeUI", 1); // HomeUI가 처음이 아님
            PlayerPrefs.Save(); // 플레이어 저장.
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

    public void SetGameOver(int score) //현재점수
    {
        ChangeState(UIState.GameOver);
        // 점수 표시
        GameUI gameUI = FindObjectOfType<GameUI>();
        if (gameUI != null)
        {
            gameUI.UpScoreText(score);
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