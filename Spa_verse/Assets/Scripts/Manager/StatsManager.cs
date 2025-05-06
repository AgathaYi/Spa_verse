using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    GameManager gameManager;
    // 점수, 코인, 점수가 쌓이면, 레벨Up에 따른 zone 오픈 여부 => 계산로직 및 데이터 저장
    public int score = 0;
    public int coin = 0;
    //public int level = 1;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("점수: " + score);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UIManager.UpdateScoreUI(score);
        }
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        Debug.Log("코인: " + coin);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UIManager.UpdateCoinUI(coin);
        }
    }

    //public void LevelUp()
    //{
    //    level++;
    //    Debug.Log("레벨: " + level);
    //}
}
