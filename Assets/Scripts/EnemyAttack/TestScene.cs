using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScene : MonoBehaviour
{
    EnemyAttackManager manager;
    List<GameObject> playerLife = new List<GameObject>();
    bool lifeActive = false;
    int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(-100, 450);
        for(int i = 0; i < 3; ++i)
        {
            //ファイアーボールの生成
            var life = new GameObject("LifeImage");
            //Canvasに親子付け
            life.transform.parent = GameObject.Find("Canvas").transform;
            //座標などの設定
            life.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            life.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y, 0);
            life.GetComponent<RectTransform>().localScale = new Vector3(2.5f, 2.5f, 2.5f);
            //画像の読み込み
            life.AddComponent<Image>().sprite = Resources.Load<Sprite>("Life");
            life.GetComponent<Image>().preserveAspect = true;
            life.GetComponent<Image>().SetNativeSize();

            life.SetActive(false);

            playerLife.Add(life);
            pos.x += 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeActive == false)
        {
            cnt++;
            if (cnt > 180)
            {
                LifeActive();
            }
        }
        manager = GameObject.Find("GameScene").GetComponent<EnemyAttackManager>();
        manager.ManagedUpdate();
    }

    private void LifeActive()
    {
        for(int i = 0; i < playerLife.Count; ++i)
        {
            playerLife[i].SetActive(true);
        }
        lifeActive = true;
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

    public bool IsPlayerLife()
    {
        if(playerLife.Count == 0)
        {
            return true;
        }
        return false;
    }
}
