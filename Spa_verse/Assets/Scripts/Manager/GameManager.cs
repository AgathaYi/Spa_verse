using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public StatsManager StatsManager { get; private set; } // 점수, 코인 등
    public ZoneBtn ZoneBtn { get; private set; } // 씬 전환버튼
    public UIManager UIManager { get; private set; }

    private string targetSceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않음!!

            StatsManager = gameObject.AddComponent<StatsManager>();
            ZoneBtn = FindAnyObjectByType<ZoneBtn>(); // 씬 전환 버튼 컴포넌트 가져오기
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 경우 중복 방지!!
        }

    }

    //==========================  ▲ ===============================//

    // 게임 시작, 일시정지, 재시작, 종료, 클리어, 플레이어와 게임사이 시스템 관리, 및 데이터 저장

    private void Start()
    {
        // UI매니져 null 계속 뜸.. 씬에서 찾아오고, 없으면 문제 될 수 있움
        UIManager = FindObjectOfType<UIManager>(true);
        if (UIManager == null)
        {
            Debug.Log("UI매니져 못찾았음");
        }
        
    }

    void Update()
    {

    }

    //==========================  메인씬  ===============================//

    public void GameStart()
    {
        Time.timeScale = 1f; // 메인씬 동작 시작
        Debug.Log("게임 시작");
        // RedZone 지하던전 훈련가능한 기능 만들기
    }

    //==========================  미니게임 ===============================//

    public void ResetScene(string sceneName)
    {
        UIManager = FindObjectOfType<UIManager>(true);

        //UI매니져/zoneBtn/ null이어도 플레이어 연결 되어야함.
        if (UIManager == null)
        {
            Debug.Log("UI매니져 못찾았음");
            return;
        }
        if (ZoneBtn == null)
        {
            Debug.Log("ZoneBtn 못찾았음");
            return;
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("플레이어 못찾았음");
            return;
        }
        else // 플레이어 wasd 동작 안함 해결
        {
            var playerHandler = player.GetComponent<MainPlayerHandler>();
            if (playerHandler != null)
            {
                playerHandler.enabled = true;
            }
            else
            {
                Debug.Log("플레이어 핸들러 못찾았음");
            }
        }

            switch (sceneName)
            {
                case "MainScene":
                    break;

                case "BlueZone":
                    // 블루존 Init 코드
                    break;

                case "RedZone":
                    // 레드존 Init 코드
                    break;

                //case "GreenZoneBtn":
                //    break;

                //case "YellowZoneBtn":
                //    break;

                default:
                    Debug.LogError("Zone 이름 확인 필요 : " + sceneName);
                    break;
            }
    }


    // ZoneBtn null 일떄 씬 전환사용을 위함.. 
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
