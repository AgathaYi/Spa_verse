using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        startUI = GetComponentInChildren<StartUI>();
        startUI.Init(this);
        gameUI = FindObjectOfType<GameUI>();
        gameUI.Init(this);
        gameOverUI = FindObjectOfType<GameOverUI>();
        gameOverUI.Init(this);

        ChangeState(UIState.Start);

    }

    // 씬별 초기화
    public void ResetSceneUI()
    {
        startUI = FindObjectOfType<StartUI>();
        if (startUI != null)
        {
            startUI.Init(this);
        }

        gameUI = FindObjectOfType<GameUI>();
        if (gameUI != null)
        {
            gameUI.Init(this);
        }

        gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.Init(this);
        }

        ChangeState(UIState.Start);
    }


    // 게임 시작 창~~
    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

    public void ChangeWave(int waveIndex)
    {
        gameUI.UpdateWaveText(waveIndex);
    }

    public void ChanPlayerHp(float currentHp, float maxHp)
    {
        gameUI.UpdateHpSlider(currentHp / maxHp);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        startUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }
}