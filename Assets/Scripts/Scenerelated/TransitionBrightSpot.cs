using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TransitionBrightSpot : MonoBehaviour
{
    [SerializeField]
    private Material _transitionIn;

    void Start()
    {
        StartCoroutine(BeginTransition());
    }

    IEnumerator BeginTransition()
    {
        yield return Animate(_transitionIn, 1);
    }

    /// <summary>
    /// time�b�����ăg�����W�V�������s��
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>


    IEnumerator Animate(Material material, float time)
    {
        GetComponent<Image>().material = material;
        float current = 0;
        while (current < time)
        {
            material.SetFloat("_Alpha", 1 - current / time);
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 0);
    }
}