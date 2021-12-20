using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x >= 197)
        {
            transform.localPosition = new Vector3(0, 0);
        }
        else
        {
            transform.localPosition += new Vector3(Time.deltaTime * 30, Time.deltaTime * 30);
        }

    }
}
