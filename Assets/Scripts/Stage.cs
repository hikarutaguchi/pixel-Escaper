using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Stage : MonoBehaviour
{
    [SerializeField] private GameObject tileMap;

    int[,] isMove = new int[5, 5];
    List<GameObject> sprites = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 5; ++x)
        {
            for(int y = 0; y < 5; ++y)
            {
                isMove[x,y] = 0;
            }
        }
        isMove[1, 1] = 1;
        CreateNoMoveSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Delete()
    {
        foreach(var data in sprites)
        {
            Destroy(data);
            sprites.Remove(data);
        }
    }

    public void CreateNoMoveSprite()
    {
        var tilemap = tileMap.GetComponent<Tilemap>();
        Vector3 pos = new Vector3();
        for (int x = 0; x < 5; ++x)
        {
            for (int y = 0; y < 5; ++y)
            {
                if(isMove[x,y] == 1)
                {
                    Vector3Int cell = new Vector3Int(x, y - 5, 0);
                    pos = tilemap.CellToWorld(cell);
                }
            }
        }
       
        var sprite = new GameObject("NoMove");
        sprite.transform.parent = GameObject.Find("Canvas").transform;
        sprite.AddComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        sprite.GetComponent<RectTransform>().position = new Vector3(pos.x + 0.5f, pos.y + 0.5f, 0.0f);
        sprite.GetComponent<RectTransform>().localScale = new Vector3(3,3,1);
        sprite.AddComponent<Image>().sprite = Resources.Load<Sprite>("rock");
        sprite.GetComponent<Image>().preserveAspect = true;
        sprite.GetComponent<Image>().SetNativeSize();
        sprites.Add(sprite);
    }

    public void SetMoveState(Vector3 pos)
    {
        isMove[(int)pos.x, (int)pos.y + 5] = 1;
    }
    public bool IsMove(Vector3 pos)
    {
        if(isMove[(int)pos.x, (int)pos.y + 5] == 1)
        {
            Debug.Log("’Ê‚ê‚ñ‚¿‚á");
            return false;
        }
        return true;
    }
}
