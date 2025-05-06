using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get => gameManager; } // �̱��� �ν��Ͻ�
    public ScoreManager ScoreManager { get; private set; } // ���� �Ŵ��� �ν��Ͻ�
    public ZoneBtn ZoneBtn { get; private set; } // �� ��ȯ��ư �ν��Ͻ�
    public UIManager UIManager { get; private set; } // UI �Ŵ��� �ν��Ͻ�

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� ����!!

            ScoreManager = gameObject.AddComponent<ScoreManager>(); // ���� �Ŵ��� ������Ʈ �߰�
            ZoneBtn = FindAnyObjectByType<ZoneBtn>(); // �� ��ȯ ��ư ������Ʈ ��������
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

    public void ResetScene(string sceneName)
    {
        switch (sceneName)
        {
            case "MainScene":
                break;

            case "BlueZone":
                // ����� Init �ڵ�
                break;

            case "RedZone":
                // ������ Init �ڵ�
                break;

            //case "GreenZoneBtn":
            //    break;

            //case "YellowZoneBtn":
            //    break;

            default:
                Debug.LogError("Zone �̸� Ȯ�� �ʿ� : "+ sceneName);
                break;
        }
    }
}
