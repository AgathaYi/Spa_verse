using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueGameManager : MonoBehaviour
{
    static BlueGameManager blueGameManager;
    public static BlueGameManager Instance { get => blueGameManager; }

    private int currentScore = 0; // ���� ����

    private void Awake()
    {
        blueGameManager = this;
    }

    public void GameOver()
    {
        Debug.Log("���� ����");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore (int score)
    {
        currentScore += score;
        Debug.Log("���� ����: " + currentScore);
    }
}
