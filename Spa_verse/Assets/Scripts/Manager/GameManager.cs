using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public StatsManager StatsManager { get; private set; } // ����, ���� ��
    public HomeUI HomeUI { get; private set; } // �� ��ȯ��ư
    public UIManager UIManager { get; private set; }

    private string targetSceneName;
    private bool notFirstHomeUI = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� ����!!

            StatsManager = gameObject.AddComponent<StatsManager>();
            HomeUI = FindAnyObjectByType<HomeUI>(); // �� ��ȯ ��ư ������Ʈ ��������
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϴ� ��� �ߺ� ����!!
        }

    }

    //==========================  �� ===============================//

    // ���� ����, �Ͻ�����, �����, ����, Ŭ����, �÷��̾�� ���ӻ��� �ý��� ����, �� ������ ����

    private void Start()
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
        UIManager = FindObjectOfType<UIManager>(true);

        //UI�Ŵ���/HomeUI/ null�̾ �÷��̾� ���� �Ǿ����.
        if (UIManager == null)
        {
            Debug.Log("UI�Ŵ��� ��ã����");
            return;
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("�÷��̾� ��ã����");
            return;
        }
        else // �÷��̾� wasd ���� ���� �ذ�
        {
            var playerHandler = player.GetComponent<MainPlayerHandler>();
            if (playerHandler != null)
            {
                playerHandler.enabled = true;
            }
            else
            {
                Debug.Log("�÷��̾� �ڵ鷯 ��ã����");
            }
        }

        switch (sceneName)
        {
            case "MainScene":
                if (!notFirstHomeUI)
                {
                    // ���� ���۽ÿ��� ������ UI
                    UIManager.ChangeState(UIState.Home);
                    notFirstHomeUI = true;
                }
                else
                {
                    // �÷����� ������ UI
                    UIManager.ChangeState(UIState.Game);
                }
                break;

            case "BlueZone":
                break;

            case "RedZone":
                break;

            //case "GreenZone":
            //    break;

            //case "YellowZone":
            //    break;

            default:
                Debug.LogError("Zone �̸� Ȯ�� �ʿ� : " + sceneName);
                break;
        }
    }


    // HomeUI null �ϋ� �� ��ȯ����� ����.. 
    public void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        ResetScene(scene.name);
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    public void OnClickSceneChangeBtn()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        SceneManager.LoadScene(targetSceneName);
    }

}
