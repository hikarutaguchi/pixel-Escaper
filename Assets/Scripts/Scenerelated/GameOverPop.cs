using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y >= 257)
        {
            transform.localPosition -= new Vector3(0, 50 * Time.deltaTime);
        }
        else
        {
            transform.localPosition = new Vector3(0, 256);
        }
    }
}
