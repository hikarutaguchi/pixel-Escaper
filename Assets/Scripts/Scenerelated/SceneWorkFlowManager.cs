using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneManager", menuName = "SceneScript/SceneManager")]
public class SceneWorkFlowManager : ScriptableObject
{
    /// <summary>
    /// シーンのロードとアンロードを行う
    /// </summary>
    public List<SceneParameter> _scenes = new List<SceneParameter>();

    public void LoadGameScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.GameScene);

        Debug.Log("load:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.LoadSceneAsync(menuScene._sceneName);
        }
    }
    public void LoadGameOverScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.GameOverScene);

        Debug.Log("load:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.LoadSceneAsync(menuScene._sceneName);
        }
    }
    public void LoadGameClearScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.GameClearScene);

        Debug.Log("load:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.LoadSceneAsync(menuScene._sceneName);
        }
    }
    public void LoadTitleScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.TitleScene);

        Debug.Log("load:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.LoadSceneAsync(menuScene._sceneName);
        }
    }
    public void LoadSelectScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.SelectScene);

        Debug.Log("load:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.LoadSceneAsync(menuScene._sceneName);
        }
    }

    public void UnLoadGameScene()
    {
        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.GameScene);

        Debug.Log("unload:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.UnloadSceneAsync(menuScene._sceneName, UnloadSceneOptions.None);
        }
    }
    public void UnLoadGameOverScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.GameOverScene);

        Debug.Log("unload:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.UnloadSceneAsync(menuScene._sceneName, UnloadSceneOptions.None);
        }
    }
    public void UnLoadGameClearScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.GameClearScene);

        Debug.Log("unload:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.UnloadSceneAsync(menuScene._sceneName, UnloadSceneOptions.None);
        }
    }
    public void UnLoadTitleScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.TitleScene);

        Debug.Log("unload:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.UnloadSceneAsync(menuScene._sceneName, UnloadSceneOptions.None);
        }
    }
    public void UnLoadSelectScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == SceneType.SelectScene);

        Debug.Log("unload:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.UnloadSceneAsync(menuScene._sceneName, UnloadSceneOptions.None);
        }
    }
}
