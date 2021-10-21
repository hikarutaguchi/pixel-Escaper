using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dagger : MonoBehaviour, EnemyAttackInterface
{
    WeaponData weaponData;
    GameObject image;
   
    public void Init()
    {
        image = new GameObject("daggerImage");
        image.transform.parent = GameObject.Find("Canvas").transform;
        image.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        image.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        image.AddComponent<Image>().sprite = Resources.Load<Sprite>("dagger");
        image.GetComponent<Image>().preserveAspect = true;
        image.GetComponent<Image>().SetNativeSize();
    }

    public void WeaponUpdate()
    {
        image.transform.localPosition += new Vector3(0.5f, 0.0f, 0.0f);
    }
}
