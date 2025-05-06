using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // 점수, 코인, 점수가 쌓이면, 레벨Up에 따른 zone 오픈 여부 => 계산로직 및 데이터 저장

    public int totalScore { get; private set; } // 총 점수
    public int totalCoin { get; private set; } // 총 코인
    //public int level;

    public void AddScore(int amount)
    {
        totalScore += amount;
        Debug.Log("점수: " + totalScore);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UIManager.UpdateScoreUI(totalScore);
        }
    }

    public void AddCoin(int amount)
    {
        totalCoin += amount;
        Debug.Log("코인: " + totalCoin);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UIManager.UpdateCoinUI(totalCoin);
        }
    }

    //public void LevelUp()
    //{
    //    level++;
    //    Debug.Log("레벨: " + level);
    //}
}
