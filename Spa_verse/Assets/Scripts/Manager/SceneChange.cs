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

    public static void Load(string sceneName, UnityAction<Scene, LoadSceneMode> onLoaded)
    {
        UnityAction<Scene, LoadSceneMode> handler = null;
        handler = (scene, mode) =>
        {
            SceneManager.sceneLoaded -= handler;
            onLoaded?.Invoke(scene, mode);
        };
        SceneManager.sceneLoaded += handler;
        SceneManager.LoadScene(sceneName);
    }
}
