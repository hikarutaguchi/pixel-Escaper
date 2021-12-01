using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    EnemyAttackManager manager;
    // Start is called before the first frame update
    void Start()
    {
        Music.Play("Square");
    }

    // Update is called once per frame
    void Update()
    {
        if (Music.IsJustChangedAt(1, 0, 1))
        {
            manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
            manager.CreateDagger();
        }
        if (Music.IsJustChangedAt(1, 2, 0))
        {
            manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
            manager.CreateDagger();
        }
        if (Music.IsJustChangedAt(1, 2, 3))
        {
            manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
            manager.CreateDagger();
        }
        //if(Music.IsJustChangedBar())
        //{
        //    manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
        //    manager.CreateDagger();
        //}
        //if (Music.IsJustChangedBeat())
        //{
        //    manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
        //    manager.CreateDagger();
        //}
    }
}
