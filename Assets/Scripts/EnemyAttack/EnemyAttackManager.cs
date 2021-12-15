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
        dagger.GetComponent<Dagger>().Init(dagger);

        weapon.Add(dagger);
    }

    public void CreateLaser(Vector3 pos)
    {
        var laser = new GameObject("laserImage");
        laser.transform.parent = GameObject.Find("Canvas").transform;
        laser.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        laser.GetComponent<RectTransform>().localPosition = new Vector3(500, pos.y, 0);
        laser.GetComponent<RectTransform>().localScale = new Vector3(5.0f, 0.1f, 1.0f);
        laser.AddComponent<Image>().sprite = Resources.Load<Sprite>("Weapon/Laser");
        laser.GetComponent<Image>().preserveAspect = true;
        laser.GetComponent<Image>().SetNativeSize();
        laser.AddComponent<Laser>();
        laser.GetComponent<Laser>().Init(laser);

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
