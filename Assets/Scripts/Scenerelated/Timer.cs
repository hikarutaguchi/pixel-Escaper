using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float countTime = 60;

    public bool timerFlag = false;

    public bool gameclearFlag = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (timerFlag)
        {
            // countTime‚ÉAƒQ[ƒ€‚ªŠJn‚µ‚Ä‚©‚ç‚Ì•b”‚ğŠi”[
            countTime -= Time.deltaTime;
        }

        if(!gameclearFlag)
        {
            if (countTime <= 0)
            {
                countTime = 0;
                gameclearFlag = true;
            }
            // ¬”2Œ…‚É‚µ‚Ä•\¦
            GetComponent<Text>().text = countTime.ToString("F2");

            if (GetComponent<Text>().text.Length <= 4)
            {
                GetComponent<Text>().text = GetComponent<Text>().text.Insert(0, "0");
            }

            GetComponent<Text>().text = GetComponent<Text>().text.Insert(0, " ");
        }
    }
}
