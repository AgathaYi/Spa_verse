using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // ����, ����, ������ ���̸�, ����Up�� ���� zone ���� ���� => ������ �� ������ ����

    public int totalScore { get; private set; } // �� ����
    public int totalCoin { get; private set; } // �� ����
    //public int level;

    public void AddScore(int amount)
    {
        totalScore += amount;
        Debug.Log("����: " + totalScore);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UIManager.UpdateScoreUI(totalScore);
        }
    }

    public void AddCoin(int amount)
    {
        totalCoin += amount;
        Debug.Log("����: " + totalCoin);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UIManager.UpdateCoinUI(totalCoin);
        }
    }

    //public void LevelUp()
    //{
    //    level++;
    //    Debug.Log("����: " + level);
    //}
}
