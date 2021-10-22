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
    public List<SceneParameter> _scenes = new List<SceneParameter>();

    public SceneType _type;

    public void LoadScene()
    {

        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == _type);

        Debug.Log("load:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.LoadSceneAsync(menuScene._sceneName);
        }
    }

    public void UnLoadScene()
    {
        var menuScene = _scenes.SingleOrDefault(p => p._sceneType == _type);

        Debug.Log("unpop:" + menuScene._sceneName);

        if (menuScene != null)
        {
            SceneManager.UnloadSceneAsync(menuScene._sceneName, UnloadSceneOptions.None);
        }
    }
}
