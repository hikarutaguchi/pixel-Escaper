using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    EnemyAttackManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
        manager.ManagedUpdate();
    }
}