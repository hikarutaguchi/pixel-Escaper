using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneCtl : MonoBehaviour
{
    public SceneWorkFlowManager manager;
    bool _clearFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transition>().StartTransitionIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Transition>().StartTransitionOut();
        }
        if (GetComponent<Transition>().GetFinishFlag())
        {
            manager.LoadGameClearScene();
        }
    }
}
