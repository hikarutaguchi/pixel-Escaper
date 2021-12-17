using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScroll : MonoBehaviour
{
    //スクロールスピード
    [SerializeField] float speed = 1;

    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed,0);   

        if (transform.localPosition.x <= -2040)
        {
            transform.localPosition = new Vector3(2040, 0, transform.localPosition.z);
        }
    }
}
