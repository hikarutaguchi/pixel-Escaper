using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType
{
    TitleScene,
    SelectScene,

}

[CreateAssetMenu(fileName = "NewScene", menuName = "SceneScript/Scene")]

public class SceneParameter : ScriptableObject
{
    [Header("Scene Information")]
    
    public string _sceneName;
    public string _memoText;
    public SceneType _sceneType;
}
