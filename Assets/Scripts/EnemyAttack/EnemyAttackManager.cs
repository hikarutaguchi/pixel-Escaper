using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackManager : MonoBehaviour
{
    List<GameObject> weapon = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFireBall(Vector3 pos, bool isVertical)
    {
        //ファイアーボールの生成
        var fireBall = new GameObject("fireImage");
        //Canvasに親子付け
        fireBall.transform.parent = GameObject.Find("Canvas").transform;
        //座標などの設定
        fireBall.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        fireBall.GetComponent<RectTransform>().position = new Vector3(pos.x, pos.y, 0);
        fireBall.GetComponent<RectTransform>().localScale = new Vector3(3.0f, 3.0f, 3.0f);
        //画像の読み込み
        fireBall.AddComponent<Image>().sprite = Resources.Load<Sprite>("Weapon/fireBall");
        fireBall.GetComponent<Image>().preserveAspect = true;
        fireBall.GetComponent<Image>().SetNativeSize();
        //当たり判定
        BoxCollider2D hitbox = fireBall.AddComponent<BoxCollider2D>();
        hitbox.size = new Vector2(30, 30);
        hitbox.isTrigger = true;

        Rigidbody2D rigidbody = fireBall.AddComponent<Rigidbody2D>();
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.simulated = true;
        rigidbody.gravityScale = 0.0f;
        //ファイアーボールスクリプトの追加
        fireBall.AddComponent<FireBall>();
        fireBall.GetComponent<FireBall>().Init(fireBall, isVertical);

        weapon.Add(fireBall);
    }

    public void CreateFireBallX(Vector3 pos)
    {
        pos.x = 12.0f;
        CreateFireBall(pos, false);
    }

    public void CreateFireBallY(Vector3 pos)
    {
        pos.y = 9.0f;
        CreateFireBall(pos, true);
    }

    public void CreateLaserX(Vector3 pos)
    {
        pos.x = 2000.0f;
        var scale = new Vector3(5.0f, 0.1f, 1.0f);
        LaserSetting(pos, scale, false);
    }

    public void CreateLaserY(Vector3 pos)
    {
        pos.y = 2000.0f;
        var scale = new Vector3(0.1f, 5.0f, 1.0f);
        LaserSetting(pos, scale, true);
    }

    private void LaserSetting(Vector3 pos, Vector3 scale, bool isVertical)
    {
        //レーザーの生成
        var laser = new GameObject("laserImage");
        //Canvasに親子付け
        laser.transform.parent = GameObject.Find("Canvas").transform;
        //座標などの設定
        laser.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        laser.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y, 0);
        laser.GetComponent<RectTransform>().localScale = new Vector3(scale.x * 5, scale.y * 5, scale.z);
        //画像の読み込み
        laser.AddComponent<Image>().sprite = Resources.Load<Sprite>("Weapon/Laser");
        laser.GetComponent<Image>().preserveAspect = true;
        laser.GetComponent<Image>().SetNativeSize();
        //当たり判定
        BoxCollider2D hitbox = laser.AddComponent<BoxCollider2D>();
        hitbox.size = new Vector2(100, 100);
        hitbox.isTrigger = true;

        Rigidbody2D rigidbody = laser.AddComponent<Rigidbody2D>();
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        rigidbody.simulated = true;
        rigidbody.gravityScale = 0.0f;
        //レーザースクリプトを追加
        laser.AddComponent<Laser>();
        laser.GetComponent<Laser>().Init(laser, isVertical);

        weapon.Add(laser);
    }

    public void ManagedUpdate()
    {
        if(weapon != null)
        {
            foreach(var data in weapon.ToArray())
            {
                if(data != null)
                {
                    var weaponTarget = data.GetComponent<EnemyAttackInterface>();
                    if (weaponTarget != null)
                    {
                        data.GetComponent<EnemyAttackInterface>().WeaponUpdate(data);
                    }
                }
            }
        }
    }

    public void DeleteObject(GameObject obj)
    {
        if(weapon.Contains(obj))
        {
            weapon.Remove(obj);
        }
    }
}
