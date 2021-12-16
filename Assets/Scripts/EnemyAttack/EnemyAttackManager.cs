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

    public void CreateDagger()
    {
        var dagger = new GameObject("daggerImage");
        dagger.transform.parent = GameObject.Find("Canvas").transform;
        dagger.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        dagger.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        dagger.AddComponent<Image>().sprite = Resources.Load<Sprite>("Weapon/dagger");
        dagger.GetComponent<Image>().preserveAspect = true;
        dagger.GetComponent<Image>().SetNativeSize();
        dagger.AddComponent<Dagger>();
        dagger.GetComponent<Dagger>().Init(dagger, false);

        weapon.Add(dagger);
    }

    public void CreateLaserX(Vector3 pos)
    {
        pos.x = 500.0f;
        var scale = new Vector3(5.0f, 0.1f, 1.0f);
        LaserSetting(pos, scale, false);
    }

    public void CreateLaserY(Vector3 pos)
    {
        pos.y = 500.0f;
        var scale = new Vector3(0.1f, 5.0f, 1.0f);
        LaserSetting(pos, scale, true);
    }

    private void LaserSetting(Vector3 pos, Vector3 scale, bool isVertical)
    {
        var laser = new GameObject("laserImage");
        laser.transform.parent = GameObject.Find("Canvas").transform;
        laser.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        laser.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, pos.y, 0);
        laser.GetComponent<RectTransform>().localScale = new Vector3(scale.x, scale.y, scale.z);
        laser.AddComponent<Image>().sprite = Resources.Load<Sprite>("Weapon/Laser");
        laser.GetComponent<Image>().preserveAspect = true;
        laser.GetComponent<Image>().SetNativeSize();
        laser.AddComponent<Laser>();
        laser.GetComponent<Laser>().Init(laser, isVertical);

        weapon.Add(laser);
    }

    public void ManagedUpdate()
    {
        if(weapon != null)
        {
            foreach(var data in weapon)
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
