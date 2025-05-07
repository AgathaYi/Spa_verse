using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseUI : MonoBehaviour
{
    // start, game, gameover UI 공통 초기화 및 활성화 비활성화

    protected UIManager uiManager;
    public abstract UIState GetUIState { get; }

    public virtual void Init(UIManager uiMng)
    {
        uiManager = uiMng;
    }

    public void SetActive(UIState state)
    {
        gameObject.SetActive(state == GetUIState);
    }
}
