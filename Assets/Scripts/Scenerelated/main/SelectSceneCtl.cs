using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSceneCtl : MonoBehaviour
{
    public SceneWorkFlowManager manager;

    [SerializeField]  Button button;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transition>().StartTransitionIn();
        //ボタンが選択された状態になる
        button.Select();
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
            manager.LoadGameScene();
        }
    }

}
