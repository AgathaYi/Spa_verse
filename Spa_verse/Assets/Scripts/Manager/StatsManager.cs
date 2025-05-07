using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // ����, ����, ������ ���̸�, ����Up�� ���� zone ���� ���� => ������ �� ������ ����
    public static StatsManager Instance { get; private set; }
    public int totalScore { get; private set; } // �� ����
    public int totalCoin { get; private set; } // �� ����

    //[SerializeField] private TextMeshProUGUI int level;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� ����!!
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϴ� ��� �ߺ� ����!!
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
    //} =UI�Ŵ�����


    //public void LevelUp()
    //{
    //    level++;
    //    Debug.Log("����: " + level);
    //}
}
