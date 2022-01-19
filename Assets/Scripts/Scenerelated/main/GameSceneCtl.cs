using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneCtl : MonoBehaviour
{
    public SceneWorkFlowManager manager;
    bool _clearFlag = false;
    [SerializeField] GameObject timer;

    private bool nextScene = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transition>().StartTransitionIn();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Transition>().GetStartFinishFlag())
        {
            timer.GetComponent<Timer>().timerFlag = true;
        }

        if (timer.GetComponent<Timer>().gameclearFlag && !nextScene)
        {
            nextScene = true;
            GetComponent<Transition>().StartTransitionOut();
        }
        if (GetComponent<Transition>().GetFinishFlag())
        {
            manager.LoadGameClearScene();
        }
        var scene = GameObject.Find("GameScene").GetComponent<TestScene>();
        if(scene.IsPlayerLife() == true)
        {
            manager.LoadGameOverScene();
        }
    }
}
