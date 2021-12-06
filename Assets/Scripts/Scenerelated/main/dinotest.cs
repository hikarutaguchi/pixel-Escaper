using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinotest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var animation = GetComponent<Animator>();

        if(Input.GetKey(KeyCode.A))
        {
            animation.SetTrigger("AttackFlag");
        }
        if (Input.GetKey(KeyCode.S))
        {
            animation.SetTrigger("WorkFlag");
        }
        if (Input.GetKey(KeyCode.D))
        {
            animation.SetTrigger("HitFlag");
        }
    }
}
