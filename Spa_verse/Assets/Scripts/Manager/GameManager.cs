using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get => gameManager; } // �̱��� �ν��Ͻ�
    public StatsManager StatsManager { get; private set; } // ���� �Ŵ��� �ν��Ͻ�
    public ZoneBtn ZoneBtn { get; private set; } // �� ��ȯ��ư �ν��Ͻ�
    public UIManager UIManager { get; private set; } // UI �Ŵ��� �ν��Ͻ�

    private void Awake()
    {
        if (Instance == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� ����!!

            StatsManager = gameObject.AddComponent<StatsManager>();
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
        // UI�Ŵ��� null ��� ��.. ������ ã�ƿ���, ������ ���� �� �� �ֿ�
        UIManager = FindObjectOfType<UIManager>(true);
        if (UIManager == null)
        {
            Debug.Log("UI�Ŵ��� ��ã����");
        }
    }

    void Update()
    {

    }

    //==========================  ���ξ�  ===============================//

    public void GameStart()
    {
        Time.timeScale = 1f; // ���ξ� ���� ����
        Debug.Log("���� ����");
        // RedZone ���ϴ��� �Ʒð����� ��� �����
    }

    //==========================  �̴ϰ��� ===============================//

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
                Debug.LogError("Zone �̸� Ȯ�� �ʿ� : " + sceneName);
                break;
        }
    }

}
