using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // ����, ����, ������ ���̸�, ����Up�� ���� zone ���� ���� => ������ �� ������ ����
    public int score = 0;
    public int coin = 0;
    public int level = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("����: " + score);
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        Debug.Log("����: " + coin);
    }

    public void LevelUp()
    {
        level++;
        Debug.Log("����: " + level);
    }
}
