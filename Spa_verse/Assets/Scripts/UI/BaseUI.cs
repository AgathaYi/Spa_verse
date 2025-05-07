using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseUI : MonoBehaviour
{
    // start, game, gameover UI 공통 초기화 및 활성화 비활성화

    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public abstract UIState GetUIState { get; }

    public void SetActive(UIState state)
    {
        gameObject.SetActive(state == GetUIState);
    }
}
