using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // �̱��� �ν��Ͻ�
    public ScoreManager ScoreManager { get; private set; } // ���� �Ŵ��� �ν��Ͻ�
    public ZoneBtn ZoneBtn { get; private set; } // �� ��ȯ��ư �ν��Ͻ�
    public UIManager UIManager { get; private set; } // UI �Ŵ��� �ν��Ͻ�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� ����!!

            ScoreManager = gameObject.AddComponent<ScoreManager>(); // ���� �Ŵ��� ������Ʈ �߰�
            ZoneBtn = FindAnyObjectByType<ZoneBtn>(); // �� ��ȯ ��ư ������Ʈ ��������

            UIManager = gameObject.AddComponent<UIManager>(); // UI �Ŵ��� ������Ʈ �߰�
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϴ� ��� �ߺ� ����!!
        }
    }

    //==========================  �� ===============================//

    // ���� ����, �Ͻ�����, �����, ����, Ŭ����, �÷��̾�� ���ӻ��� �ý��� ����, �� ������ ����

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //==========================  �� ===============================//

    public void GameStart()
    {
        Debug.Log("���� ����");
    }

    public void GamePause()
    {
        Debug.Log("���� �Ͻ�����");
    }

    public void GameRestart()
    {
        Debug.Log("���� �����");
    }

    public void GameExit()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }

    public void GameClear()
    {
        Debug.Log("���� Ŭ����");
    }

    public void GameOver()
    {
        Debug.Log("���� ����");
    }
}
