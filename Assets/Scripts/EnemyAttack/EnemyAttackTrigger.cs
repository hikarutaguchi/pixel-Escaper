using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackTrigger : MonoBehaviour
{
    private enum AttackType
    {
        Dagger,
        Laser,
    }

    EnemyAttackManager manager;
    int attackCnt = 0;
    delegate bool RismAttack(AttackType type);
    List<RismAttack> attackList = new List<RismAttack>();
    int laserOffsetY = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Music.Play("Square");
        attackList.Add(OneBeatsAttack);
        attackList.Add(ThreeBeatsAttack);
        attackList.Add(FourBeatsAttack);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < attackList.Count; ++i)
        {
            if(attackList[i](AttackType.Laser) == true)
            {
                attackList.RemoveAt(i);
            }
        }
    }

    private bool OneBeatsAttack(AttackType type)
    {
        int atkCnt = 1;
        if (Music.IsJustChangedAt(1, 0, 1))
        {
            CreateAttack();
        }
        return isAttacked(atkCnt);
    }

    private bool ThreeBeatsAttack(AttackType type)
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
        return isAttacked(atkCnt);
    }

    private bool FourBeatsAttack(AttackType type)
    {
        int atkCnt = 4;
        for(int i = 0; i < atkCnt; ++i)
        {
            if (Music.IsJustChangedAt(3, i, 1))
            {
                CreateAttack();
            }
        }
        return isAttacked(atkCnt);
    }

    private bool isAttacked(int atkCnt)
    {
        if (atkCnt == attackCnt)
        {
            attackCnt = 0;
            laserOffsetY = 0;
            return true;
        }
        return false;
    }
    
    private void CreateAttack()
    {
        manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
        //manager.CreateDagger();
        CreateLaserGuid();
        attackCnt++;
    }

    public void CreateLaserGuid()
    {
        var laser = new GameObject("laserGuid");
        laser.transform.parent = GameObject.Find("Canvas").transform;
        laser.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        laser.GetComponent<RectTransform>().localPosition = new Vector3(0, laserOffsetY, 0);
        laser.GetComponent<RectTransform>().localScale = new Vector3(5.0f, 0.1f, 1.0f);
        laser.AddComponent<Image>().sprite = Resources.Load<Sprite>("Laser");
        laser.GetComponent<Image>().preserveAspect = true;
        laser.GetComponent<Image>().SetNativeSize();
        laser.AddComponent<LaserGuid>();
        laserOffsetY += 16;
    }
}
