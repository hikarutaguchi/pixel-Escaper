using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackManager : MonoBehaviour
{
    GameObject weapon;
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
        weapon = new GameObject("daggerImage");
        weapon.transform.parent = GameObject.Find("Canvas").transform;
        weapon.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        weapon.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        weapon.AddComponent<Image>().sprite = Resources.Load<Sprite>("dagger");
        weapon.GetComponent<Image>().preserveAspect = true;
        weapon.GetComponent<Image>().SetNativeSize();
        weapon.AddComponent<Dagger>();
    }

    public void ManagedUpdate()
    {
        if(weapon != null)
        {
            var weaponTarget = weapon.GetComponent<EnemyAttackInterface>();
            if (weaponTarget != null)
            {
                weapon.GetComponent<EnemyAttackInterface>().WeaponUpdate(weapon);
            }
        }
    }
}
