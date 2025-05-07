using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // 점수, 코인, 점수가 쌓이면, 레벨Up에 따른 zone 오픈 여부 => 계산로직 및 데이터 저장
    public static StatsManager Instance { get; private set; }
    public int totalScore { get; private set; } // 총 점수
    public int totalCoin { get; private set; } // 총 코인

    //[SerializeField] private TextMeshProUGUI int level;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않음!!
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 경우 중복 방지!!
        }
    }

    private void Start()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScoreUI(totalScore);
            UIManager.Instance.UpdateCoinUI(totalCoin);
        }
    }


    public void AddScore(int amount)
    {
        totalScore += amount;
        UIManager.Instance.UpdateScoreUI(totalScore);
    }

    public void AddCoin(int amount)
    {
        totalCoin += amount;
        UIManager.Instance.UpdateCoinUI(totalCoin);
    }

    //public void UpdateScoreUI(int score)
    //{
    //    if (scoreText != null)
    //    {
    //        scoreText.text = score.ToString();
    //    }
    //}

    //public void UpdateCoinUI(int coin)
    //{
    //    if (coinText != null)
    //    {
    //        coinText.text = coin.ToString();
    //    }
    //} =UI매니져로


    //public void LevelUp()
    //{
    //    level++;
    //    Debug.Log("레벨: " + level);
    //}
}
