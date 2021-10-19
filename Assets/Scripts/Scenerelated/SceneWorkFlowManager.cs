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
    public List<SceneParameter> Menus = new List<SceneParameter>();

    public void LoadScene(SceneType type)
    {
        var menuScene = Menus.SingleOrDefault(p => p._sceneType == type);

        Debug.Log("load:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.LoadSceneAsync(menuScene._sceneName);
        }
    }

    public void UnLoadScene(SceneType type)
    {
        var menuScene = Menus.SingleOrDefault(p => p._sceneType == type);

        Debug.Log("unpop:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.UnloadSceneAsync(menuScene._sceneName, UnloadSceneOptions.None);
        }
    }
}
