using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionUI;

    GameObject square;
    MusicUnity music;
    MusicBase carrent;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            OptionUI.SetActive(!OptionUI.activeSelf);

            //�@�|�[�YUI���\������Ă鎞�͒�~
            if (OptionUI.activeSelf)
            {
               
                Time.timeScale = 0f;
                //�@�|�[�YUI���\������ĂȂ���Βʏ�ʂ�i�s
            }
            else
            {

                Time.timeScale = 1f;
            }
        }
    }
}
