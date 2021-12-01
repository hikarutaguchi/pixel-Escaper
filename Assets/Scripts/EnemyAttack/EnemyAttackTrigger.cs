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
        
        if (Music.IsJustChangedBeat())
        {
            manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
            manager.CreateDagger();
        }
    }
}
