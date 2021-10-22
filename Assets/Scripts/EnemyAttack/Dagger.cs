using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dagger : MonoBehaviour, EnemyAttackInterface
{
    WeaponData weaponData;
   
    public void Init()
    {
        
    }

    public void WeaponUpdate(GameObject weapon)
    {
        weapon.transform.localPosition += new Vector3(0.5f, 0.0f, 0.0f);
    }
}
