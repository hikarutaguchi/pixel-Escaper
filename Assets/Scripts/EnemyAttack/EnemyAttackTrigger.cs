using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class EnemyAttackTrigger : MonoBehaviour
{
    private enum AttackType
    {
        Dagger,
        Laser,
    }

    [SerializeField] private GameObject tileMap;
    EnemyAttackManager manager;
    delegate bool RismAttack(AttackType type);
    List<RismAttack> attackList = new List<RismAttack>();
    int attackCnt = 0;
    float laserOffsetY = 0.0f;
    float laserOffsetX = 0.0f;
    bool isVertical = false;
    Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        Music.Play("Square");
        LaserPosSet();
        attackList.Add(OneBeatsAttack);
        attackList.Add(ThreeBeatsAttack);
        attackList.Add(FourBeatsAttack);
    }

    public void AddOneAttack()
    {
        attackList.Add(OneBeatsAttack);
    }
    public void AddThreeAttack()
    { 
        attackList.Add(ThreeBeatsAttack);
    }
    public void AddFourAttack()
    {
        attackList.Add(FourBeatsAttack);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < attackList.Count; ++i)
        {
            if(attackList[i](AttackType.Laser) == true)
            {
                XYLaserSet();
                LaserPosSet();
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
        if (Music.IsJustChangedAt(1, 1, 1))
        {
            CreateAttack();
        }
        if (Music.IsJustChangedAt(1, 3, 0))
        {
            CreateAttack();
        }
        if (Music.IsJustChangedAt(1, 3, 3))
        {
            CreateAttack();
        }
        return isAttacked(atkCnt);
    }

    private bool FourBeatsAttack(AttackType type)
    {
        int atkCnt = 4;
        for (int i = 0; i < atkCnt; ++i)
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
            laserOffsetX = 0;
            laserOffsetY = 0;
            return true;
        }
        return false;
    }
    
    private void XYLaserSet()
    {
        int val = Random.Range(0, 2);
        if (val == 0)
        {
            isVertical = false;
        }
        else
        {
            isVertical = true;
        }
    }

    private void LaserPosSet()
    {
        var tilemap = tileMap.GetComponent<Tilemap>();
        int x = Random.Range(-6, -1);
        int y = Random.Range(-2, 3);
        var position = new Vector3Int(x, y, 0);
        startPos = tilemap.GetCellCenterLocal(position);
        laserOffsetX = startPos.x;
        laserOffsetY = startPos.y;
        //startPos = new Vector3(tilemap.GetCellCenterLocal(position).x, tilemap.GetCellCenterLocal(position).y, 0);
    }

    private void CreateAttack()
    {
        manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
        //manager.CreateDagger();
        if(isVertical == false)
        {
            CreateLaserGuidX();
        }
        else
        {
            CreateLaserGuidY();
        }
        attackCnt++;
    }

    public void CreateLaserGuidX()
    {
        Vector3 pos = new Vector3(0.0f, laserOffsetY, 0.0f);
        Vector3 scale = new Vector3(5.0f, 0.1f, 1.0f);
        LaserSetting(pos, scale);
        laserOffsetY += 1.0f;
    }

    public void CreateLaserGuidY()
    {
        Vector3 pos = new Vector3(laserOffsetX, 0.0f, 0.0f);
        Vector3 scale = new Vector3(0.1f, 5.0f, 1.0f);
        LaserSetting(pos, scale);
        laserOffsetX += 1.0f;
    }

    private void LaserSetting(Vector3 pos, Vector3 scale)
    {
        var laser = new GameObject("laserGuid");
        laser.transform.parent = GameObject.Find("Canvas").transform;
        laser.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        laser.GetComponent<RectTransform>().position = new Vector3(pos.x, pos.y, 0.0f);
        laser.GetComponent<RectTransform>().localScale = new Vector3(scale.x, scale.y, scale.z);
        laser.AddComponent<Image>().sprite = Resources.Load<Sprite>("Laser");
        laser.GetComponent<Image>().preserveAspect = true;
        laser.GetComponent<Image>().SetNativeSize();
        laser.AddComponent<LaserGuid>();
        laser.GetComponent<LaserGuid>().SetVertical(isVertical);
    }
}
