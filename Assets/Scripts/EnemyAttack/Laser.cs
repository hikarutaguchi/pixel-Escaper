using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour, EnemyAttackInterface
{
    WeaponData weaponData;

    public void Init(GameObject weapon)
    {
        weaponData = Resources.Load("WeaponAsset/Laser") as WeaponData;
    }

    public void WeaponUpdate(GameObject weapon)
    {
        weapon.transform.localPosition -= new Vector3(weaponData.speed, 0.0f, 0.0f);
    }
}
