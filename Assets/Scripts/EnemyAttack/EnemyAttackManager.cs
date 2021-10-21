using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    GameObject weapon;
    Dagger dagger;
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
        dagger = new Dagger();
        dagger.Init();
        weapon = GameObject.Find("Canvas/daggerImage");
    }

    public void ManagedUpdate()
    {
        if(weapon != null)
        {
            var weaponTarget = weapon.GetComponent<EnemyAttackInterface>();
            if (weaponTarget != null)
            {
                weapon.GetComponent<EnemyAttackInterface>().WeaponUpdate();
            }
        }
    }
}
