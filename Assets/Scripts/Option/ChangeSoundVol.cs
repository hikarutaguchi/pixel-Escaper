using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ChangeSoundVol : MonoBehaviour
{
    private AudioSource audiosource_;
    private MusicUnity obj;

    // Start is called before the first frame update
    void Start()
    {
        audiosource_ = gameObject.GetComponent<AudioSource>();
        obj = GameObject.Find("Square").GetComponent<MusicUnity>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundSliderValueChange(float newSliderVal)
    {
        obj.Volume = newSliderVal;
        audiosource_.volume = newSliderVal;
    }
}
