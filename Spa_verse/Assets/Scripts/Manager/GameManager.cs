using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get => gameManager; } // 싱글톤 인스턴스
    public ScoreManager ScoreManager { get; private set; } // 점수 매니저 인스턴스
    public ZoneBtn ZoneBtn { get; private set; } // 씬 전환버튼 인스턴스
    public UIManager UIManager { get; private set; } // UI 매니저 인스턴스

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않음!!

            ScoreManager = gameObject.AddComponent<ScoreManager>(); // 점수 매니저 컴포넌트 추가
            ZoneBtn = FindAnyObjectByType<ZoneBtn>(); // 씬 전환 버튼 컴포넌트 가져오기
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 경우 중복 방지!!
        }
    }

    //==========================  ▲ ===============================//

    // 게임 시작, 일시정지, 재시작, 종료, 클리어, 플레이어와 게임사이 시스템 관리, 및 데이터 저장

    void Start()
    {

    }

    void Update()
    {
        
    }

    //==========================  ▼ ===============================//

    public void GameStart()
    {
        Debug.Log("게임 시작");
    }

    public void GamePause()
    {
        Debug.Log("게임 일시정지");
    }

    public void GameRestart()
    {
        Debug.Log("게임 재시작");
    }

    public void GameExit()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

    public void GameClear()
    {
        Debug.Log("게임 클리어");
    }

    public void GameOver()
    {
        Debug.Log("게임 오버");
    }

    public void ResetScene(string sceneName)
    {
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
                Debug.LogError("Zone 이름 확인 필요 : "+ sceneName);
                break;
        }
    }
}
