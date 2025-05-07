using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseUI : MonoBehaviour
{
    // start, game, gameover UI ���� �ʱ�ȭ �� Ȱ��ȭ ��Ȱ��ȭ

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
