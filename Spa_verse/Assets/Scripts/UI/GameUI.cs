using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI distanceTxt;
    [SerializeField] private TextMeshProUGUI coinTxt;
    //[SerializeField] private Slider hpSlider;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (distanceTxt != null)
        {
            //hpSlider.value = 1;
            distanceTxt.text = "0";
            coinTxt.text = "0";
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
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainScene")
        {
            return;
        }

        distanceTxt.text = score.ToString();
    }

    public void UpCoinText(int coin)
    {
        coinTxt.text = coin.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}
