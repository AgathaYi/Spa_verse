using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static void otherScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 수정 필요
    public static void Load(string sceneName, UnityAction<Scene, LoadSceneMode> onLoaded)
    {
        UnityAction<Scene, LoadSceneMode> handler = null;
        handler = (score, coin) =>
        {
            SceneManager.sceneLoaded -= handler;
            onLoaded?.Invoke(score, coin);
        };
        SceneManager.sceneLoaded += handler;
        SceneManager.LoadScene(sceneName);
    }
}
