using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserGuid : MonoBehaviour
{
    float alfa = 0f;
    Color color;
    float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f, alfa);
    }

    // Update is called once per frame
    void Update()
    {
        if(EndGuid() == true)
        {
            var manager = GameObject.Find("GameObject").GetComponent<EnemyAttackManager>();
            manager.CreateLaser(this.transform.localPosition);
            Destroy(this.gameObject);
        }
    }

    private bool EndGuid()
    {
        color = this.GetComponent<Image>().color;
        alfa = color.a;
        alfa += 0.01f;
        this.GetComponent<Image>().color = new Color(color.r, color.g, color.b, alfa);
        if(alfa >= 0.75f)
        {
            return true;
        }
        return false;
    }
}
