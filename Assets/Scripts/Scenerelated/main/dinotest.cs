using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class dinotest : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject tileMap;

    public GameObject dino;

    private Vector3 pos;
    void Start()
    {
        var tilemap = tileMap.GetComponent<Tilemap>();
        var position = new Vector3Int(-4, 0, 0);
        pos = tilemap.GetCellCenterLocal(position);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        dino.transform.SetPositionAndRotation(pos, new Quaternion(0,0,0,0));
    }
}
