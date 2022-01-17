using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBall : MonoBehaviour, EnemyAttackInterface
{
    WeaponData weaponData;
    bool isVertical = false;

    public void Init(GameObject weapon, bool isVer)
    {
        weaponData = Resources.Load("WeaponAsset/FireBallStatus") as WeaponData;
        isVertical = isVer;
    }

    public void WeaponUpdate(GameObject weapon)
    {
        if (isVertical == false)
        {
            weapon.transform.localPosition -= new Vector3(weaponData.speed, 0.0f, 0.0f);
        }
        else
        {
            weapon.transform.localPosition -= new Vector3(0.0f, weaponData.speed, 0.0f);
        }

        if ((weapon.transform.localPosition.x <= -200) || (weapon.transform.localPosition.y <= -200))
        {
            var manager = GameObject.Find("GameScene").GetComponent<EnemyAttackManager>();
            manager.DeleteObject(weapon);
            Destroy(weapon);
        }
    }
}
