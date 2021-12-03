using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField]
    private Material _transition;
    public Image _fadeImage;
    private bool _finishFlag = false;
    public void StartTransitionIn()
    {
        StartCoroutine(TransitionIn());
    }

    IEnumerator TransitionIn()
    {
        yield return InAnimate(_transition, 1);
    }

    IEnumerator InAnimate(Material material, float time)
    {
        _fadeImage.GetComponent<Image>().material = material;
        float current = 0;
        while (current < time)
        {
            material.SetFloat("_Alpha", 1 - current / time);
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 0);
    }

    public void StartTransitionOut()
    {
        StartCoroutine(TransitionOut());
    }
    IEnumerator TransitionOut()
    {
        yield return OutAnimate(_transition, 1);
    }
    IEnumerator OutAnimate(Material material, float time)
    {
        _fadeImage.GetComponent<Image>().material = material;
        float current = 0;
        while (current < time)
        {
            material.SetFloat("_Alpha", current / time);
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 1);
        _finishFlag = true;
    }

    public bool GetFinishFlag() { return _finishFlag; }
}
