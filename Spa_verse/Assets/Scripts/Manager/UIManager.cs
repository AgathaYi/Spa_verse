using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState
{
    Home,
    Start,
    Game,
    GameOver,
}

public class UIManager : MonoBehaviour
{
    // 점수, 체력, 코인, 팝업, 버튼 등 => 눈에 보이는 것들

    StartUI startUI;
    GameUI gameUI;
    GameOverUI gameOverUI;

    private UIState currentState;

    private void Awake()
    {
        //씬별 초기화
        startUI = GetComponentInChildren<StartUI>(true); //UI매니져 자식 아래로만 찾기
        if (startUI != null)
        {
            startUI.Init(this);
        }

        gameUI = GetComponentInChildren<GameUI>(true);
        if (gameUI != null)
        {
            gameUI.Init(this);
        }

        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        if (gameOverUI != null)
        {
            gameOverUI.Init(this);
        }
    }

    // MiniGameZone
    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

    //public void ChanPlayerHp(float currentHp, float maxHp)
    //{
    //    gameUI.UpdateHpSlider(currentHp / maxHp);
    //}

    public void ChangeState(UIState state)
    {
        // 씬별로 UI 상태 다름
        currentState = state;

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

    public void UpdateScoreUI(int score)
    {
        if (gameUI != null)
        {
            gameUI.UpScoreText(score);

        }
    }

    public void UpdateCoinUI(int coin)
    {
        if (gameUI != null)
        {
            gameUI.UpCoinText(coin);
        }
    }

    // 씬별로 Null 값 다름.
    public void SetActive(bool isActive)
    {
        if (gameOverUI != null)
        {
            gameOverUI.gameObject.SetActive(isActive);
        }

        if (startUI != null)
        {
            startUI.gameObject.SetActive(isActive);
        }

        if (gameUI != null)
        {
            gameUI.gameObject.SetActive(isActive);
        }
    }
}