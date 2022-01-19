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
        FireBall,
        Laser,
    }

    [SerializeField] private GameObject tileMap;
    EnemyAttackManager manager;//敵攻撃の管理変数
    delegate bool RismAttack(AttackType type);//リズム攻撃
    List<RismAttack> attackList = new List<RismAttack>();//リズム攻撃の関数ポインタのリスト
    int attackCnt = 0;//攻撃回数
    float laserOffsetX = 0.0f;//レーザー初期座標のオフセット
    float laserOffsetY = 0.0f;//レーザー初期座標のオフセット
    bool isVertical = false;//縦方向かどうかのフラグ
    Vector3 laserStartPos;//初期座標
    Vector3 fireStartPos;//初期座標
    AttackType atkType = AttackType.Laser;

    // Start is called before the first frame update
    void Start()
    {
        //Music.Play("BGM");
        Music.Play("Square");
        //レーザーの初期座標をセット
        LaserPosSet();
        FireBallPosSet();
        AttackTypeSetting();
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
            if (attackList[i](atkType) == true)
            {
                VerticalSetting();
                LaserPosSet();
                FireBallPosSet();
                AttackTypeSetting();
                attackList.RemoveAt(i);
            }
        }
        if (attackList.Count == 0)
        {
            int ram = Random.Range(1, 4);
            switch (ram)
            {
                case 1:
                    AddOneAttack();
                    break;
                case 2:
                    AddThreeAttack();
                    break;
                case 3:
                    AddFourAttack();
                    break;
            }
        }
    }

    private bool OneBeatsAttack(AttackType type)
    {
        int atkCnt = 1;
        if (Music.IsJustChangedAt(1, 0, 1))
        {
            CreateAttack(type);
        }
        return isAttacked(atkCnt);
    }

    private bool ThreeBeatsAttack(AttackType type)
    {
        int atkCnt = 3;
        if (Music.IsJustChangedAt(1, 1, 1))
        {
            CreateAttack(type);
        }
        if (Music.IsJustChangedAt(1, 3, 0))
        {
            CreateAttack(type);
        }
        if (Music.IsJustChangedAt(1, 3, 3))
        {
            CreateAttack(type);
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
                CreateAttack(type);
            }
        }
        return isAttacked(atkCnt);
    }

    private bool isAttacked(int atkCnt)
    {
        //攻撃回数が規定の値に到達したか
        if (atkCnt == attackCnt)
        {
            attackCnt = 0;
            laserOffsetX = 0;
            laserOffsetY = 0;
            return true;
        }
        return false;
    }
    
    private void VerticalSetting()
    {
        //縦方向か横方向か
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

    private void AttackTypeSetting()
    {
        //縦方向か横方向か
        int val = Random.Range(0, 2);
        if (val == 0)
        {
            atkType = AttackType.FireBall;
        }
        else
        {
            atkType = AttackType.Laser;
        }
    }

    private void LaserPosSet()
    {
        var tilemap = tileMap.GetComponent<Tilemap>();
        int x = Random.Range(-5, -2);
        int y = Random.Range(-1, 2);
        var position = new Vector3Int(x, y, 0);
        laserStartPos = tilemap.GetCellCenterLocal(position);
        laserOffsetX = laserStartPos.x;
        laserOffsetY = laserStartPos.y;
    }

    private void FireBallPosSet()
    {
        var tilemap = tileMap.GetComponent<Tilemap>();
        int x = Random.Range(-6, -1);
        int y = Random.Range(-2, 3);
        var position = new Vector3Int(x, y, 0);
        fireStartPos = tilemap.GetCellCenterLocal(position);
    }

    private void CreateAttack(AttackType type)
    {
        manager = GameObject.Find("GameScene").GetComponent<EnemyAttackManager>();
        FireBallPosSet();
        switch (type)
        {
        case AttackType.FireBall:
            if (isVertical == false)
            {
                manager.CreateFireBallX(fireStartPos);
            }
            else
            {
                manager.CreateFireBallY(fireStartPos);
            }
            break;
        case AttackType.Laser:
            if (isVertical == false)
            {
                CreateLaserGuidX();
            }
            else
            {
                CreateLaserGuidY();
            }
            break;
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
        laser.GetComponent<RectTransform>().localScale = new Vector3(scale.x * 5, scale.y * 5, scale.z);
        laser.AddComponent<Image>().sprite = Resources.Load<Sprite>("Laser");
        laser.GetComponent<Image>().preserveAspect = true;
        laser.GetComponent<Image>().SetNativeSize();
        laser.AddComponent<LaserGuid>();
        laser.GetComponent<LaserGuid>().SetVertical(isVertical);
    }
}
