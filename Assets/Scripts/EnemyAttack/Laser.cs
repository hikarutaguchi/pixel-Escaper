using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour, EnemyAttackInterface
{
    WeaponData weaponData;
    float sp = 0.01f;
    float alfa;
    Color color;
    float red, green, blue;

    
    public void Init()
    {
        
    }

    public void WeaponUpdate(GameObject weapon)
    {
        color = weapon.GetComponent<Image>().color;
        red = color.r;
        green = color.g;
        blue = color.b;
        red -= 0.01f;
        green -= 0.01f;
        blue -= 0.01f;
        weapon.GetComponent<Image>().color = new Color(red, green, blue, 1.0f);
        //ColorChan();
    }

    void ColorChan()
    {
        alfa++;
        var color = this.GetComponent<Image>().color;
        red = color.r;
        green = color.g;
        blue = color.b;
        red += 0.01f;
        green += 0.01f;
        blue += 0.01f;
        color = new Color(red, green, blue, 1f);
    }
}
