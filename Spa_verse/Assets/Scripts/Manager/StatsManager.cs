using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    GameManager gameManager;
    // ����, ����, ������ ���̸�, ����Up�� ���� zone ���� ���� => ������ �� ������ ����
    public int score = 0;
    public int coin = 0;
    //public int level = 1;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("����: " + score);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UIManager.UpdateScoreUI(score);
        }
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        Debug.Log("����: " + coin);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UIManager.UpdateCoinUI(coin);
        }
    }

    //public void LevelUp()
    //{
    //    level++;
    //    Debug.Log("����: " + level);
    //}
}
