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

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI scoreText; // ����
    [SerializeField] private TextMeshProUGUI coinText; // ����
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
        UpdateScoreUI(totalScore);
        UpdateCoinUI(totalCoin);
    }


    public void AddScore(int amount)
    {
        totalScore += amount;
        UpdateScoreUI(totalScore);
    }

    public void AddCoin(int amount)
    {
        totalCoin += amount;
        UpdateCoinUI(totalCoin);
    }

    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void UpdateCoinUI(int coin)
    {
        if (coinText != null)
        {
            coinText.text = coin.ToString();
        }
    }

    //public void LevelUp()
    //{
    //    level++;
    //    Debug.Log("����: " + level);
    //}
}
