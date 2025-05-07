using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI coinTxt;
    //[SerializeField] private Slider hpSlider;

    public override UIState GetUIState => UIState.Game;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (scoreTxt != null)
        {
            UpScoreText(0);
            UpCoinText(0);
        }
    }

    //public void UpdateHpSlider(float percent)
    //{
    //    string currentSceneName = SceneManager.GetActiveScene().name;
    //    if (currentSceneName == "MainScene")
    //    {
    //        return;
    //    }
    //    hpSlider.value = percent;
    //}

    public void UpScoreText(int score)
    {
        scoreTxt.text = score.ToString();
    }

    public void UpCoinText(int coin)
    {
        coinTxt.text = coin.ToString();
    }
}
