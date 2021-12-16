using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyAttackInterface
{
    void Init(GameObject weapon, bool isVer);
    void WeaponUpdate(GameObject weapon);
}
