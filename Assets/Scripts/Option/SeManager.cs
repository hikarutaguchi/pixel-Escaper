using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;

    private AudioSource audioSource_;

    // Start is called before the first frame update
    void Start()
    {
        audioSource_ = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySe(string SeName)
    {
        switch (SeName)
        {
            case "SE0":
                audioSource_.PlayOneShot(audioClips[0]);
                break;
            case "SE1":
                audioSource_.PlayOneShot(audioClips[1]);
                break;
            case "SE2":
                audioSource_.PlayOneShot(audioClips[2]);
                break;
        }

    }
}
