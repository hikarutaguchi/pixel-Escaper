using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    EnemyAttackManager manager;
    int attackCnt = 0;
    delegate bool RismAttack();
    List<RismAttack> attackList = new List<RismAttack>();
    
    // Start is called before the first frame update
    void Start()
    {
        Music.Play("Square");
        attackList.Add(ThreeBeatsAttack);
        attackList.Add(FourBeatsAttack);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < attackList.Count; ++i)
        {
            if(attackList[i]() == true)
            {
                attackList.RemoveAt(i);
            }
        }
    }

    private bool ThreeBeatsAttack()
    {
        int atkCnt = 3;
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

    private bool FourBeatsAttack()
    {
        int atkCnt = 4;
        for(int i = 0; i < atkCnt; ++i)
        {
            if (Music.IsJustChangedAt(3, i, 1))
            {
                CreateAttack();
            }
        }
        if (atkCnt == attackCnt)
        {
            attackCnt = 0;
            return true;
        }
        return false;
    }
    
    private void CreateAttack()
    {
        manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
        manager.CreateDagger();
        attackCnt++;
    }
}
