using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScene : MonoBehaviour
{
    EnemyAttackManager manager;
    List<GameObject> playerLife = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(-32, 60);
        for(int i = 0; i < 3; ++i)
        {
            //ファイアーボールの生成
            var life = new GameObject("LifeImage");
            //Canvasに親子付け
            life.transform.parent = GameObject.Find("Canvas").transform;
            //座標などの設定
            life.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            life.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y, 0);
            life.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //画像の読み込み
            life.AddComponent<Image>().sprite = Resources.Load<Sprite>("Life");
            life.GetComponent<Image>().preserveAspect = true;
            life.GetComponent<Image>().SetNativeSize();

            playerLife.Add(life);
            pos.x += 32;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        manager = GameObject.Find("GameScene").GetComponent<EnemyAttackManager>();
        manager.ManagedUpdate();
    }

    public void PlayerDamage()
    {
        if(playerLife.Count != 0)
        {
            int lifeIdx = playerLife.Count - 1;
            Destroy(playerLife[lifeIdx]);
            playerLife.RemoveAt(lifeIdx);
        }
    }
}
