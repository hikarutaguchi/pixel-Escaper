using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneCtl : MonoBehaviour
{
    public SceneWorkFlowManager manager;

    [SerializeField] GameObject image;

    float alpha_Sin;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transition>().StartTransitionIn();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<Transition>().StartTransitionOut();
        }
        if (GetComponent<Transition>().GetFinishFlag())
        {
            manager.LoadSelectScene();
        }

        alpha_Sin = Mathf.Sin(Time.time) / 2 + 0.5f;

        StartCoroutine(ColorCoroutine());
    }

    IEnumerator ColorCoroutine()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            Color _color = image.GetComponent<SpriteRenderer>().material.color;

            _color.a = alpha_Sin;

            image.GetComponent<SpriteRenderer>().material.color = _color;
        }
    }
}
