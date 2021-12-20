using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeText : MonoBehaviour
{
    private string timing_;
    Text text_;

    private void Awake()
    {
        timing_ = GameObject.Find("Dino").GetComponent<playerController>().timing;
        text_ = this.GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timing_ = GameObject.Find("Dino").GetComponent<playerController>().timing;
        text_.text = timing_;
    }
}
