using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGameManager : MonoBehaviour
{
    public static RedGameManager Instance { get; private set; } // 싱글톤 인스턴스

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        Debug.Log("게임 시작");
    }
}
