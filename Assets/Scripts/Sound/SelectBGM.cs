using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBGM : MonoBehaviour
{
    private AudioSource a;  //AudioSourceŒ^‚Ì•Ï”a‚ğéŒ¾
    private AudioClip[] num;
    public int cnt_;

    private void Init()
    {
        //num = this.GetComponent<MusicUnity>().Sections[0].Clips;
        //a = this.GetComponent<AudioSource>();
        //cnt_ = 0;
        //a.clip = num[cnt_];
        //a.Play();
        //this.GetComponent<MusicUnity>().Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{

        //    cnt_++;
        //    if (cnt_ < num.Length)
        //    {
        //        a.clip = num[cnt_];
        //        a.Play();
        //    }
        //    else
        //    {
        //        cnt_ = 0;
        //        a.clip = num[cnt_];
        //        a.Play();
        //    }
        //}
    }
}
