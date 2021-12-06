using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    EnemyAttackManager manager;
    int attackCnt = 0;
    delegate bool RismAttack(int atkCnt);
    RismAttack rismAttack;

    // Start is called before the first frame update
    void Start()
    {
        Music.Play("Square");
        rismAttack = RismAttack2;
    }

    // Update is called once per frame
    void Update()
    {
        if(rismAttack != null)
        {
            if (rismAttack(3))
            {
                rismAttack -= RismAttack2;
            }
        }
    }

    public bool RismAttack2(int atkCnt)
    {
        if (Music.IsJustChangedAt(1, 0, 1))
        {
            CreateAttack();
        }
        if (Music.IsJustChangedAt(1, 2, 0))
        {
            CreateAttack();
        }
        if (Music.IsJustChangedAt(1, 2, 3))
        {
            CreateAttack();
        }
        if(atkCnt == attackCnt)
        {
            attackCnt = 0;
            return true;
        }
        return false;
    }

    void CreateAttack()
    {
        manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
        manager.CreateDagger();
        attackCnt++;
    }
}
