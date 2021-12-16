using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScroll : MonoBehaviour
{
    //スクロールスピード
    [SerializeField] float speed = 1;

    [SerializeField] bool mountain = false;

    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed,0);

        if(mountain)
        {
            if (transform.localPosition.x <= -1810)
            {
                transform.localPosition = new Vector3(3210, 0, transform.localPosition.z);
            }
        }
        else
        {
            if (transform.localPosition.x <= -2040)
            {
                transform.localPosition = new Vector3(2040, 0, transform.localPosition.z);
            }
        }
    }
}
