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

            //　ポーズUIが表示されてる時は停止
            if (OptionUI.activeSelf)
            {
               
                Time.timeScale = 0f;
                //　ポーズUIが表示されてなければ通常通り進行
            }
            else
            {

                Time.timeScale = 1f;
            }
        }
    }
}
