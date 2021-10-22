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
        var daga = Resources.Load("Resources/WeaponAsset/dagger") as WeaponData;

        var dagger = new GameObject("daggerImage");
        dagger.transform.parent = GameObject.Find("Canvas").transform;
        dagger.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        dagger.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        dagger.AddComponent<Image>().sprite = Resources.Load<Sprite>("dagger");
        dagger.GetComponent<Image>().preserveAspect = true;
        dagger.GetComponent<Image>().SetNativeSize();
        dagger.AddComponent<Dagger>();

        weapon.Add(dagger);
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
