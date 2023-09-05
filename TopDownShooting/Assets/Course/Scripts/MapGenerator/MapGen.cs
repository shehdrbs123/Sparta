using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;
[RequireComponent(typeof(Tilemap),typeof(TilemapRenderer))]
[ExecuteAlways]
public class MapGen : MonoBehaviour
{
    private Tilemap tilemap;

    [SerializeField] private TileBase[] groundTiles;

    [SerializeField] private int halfSizeX;

    [SerializeField] private int halfSizeY;
    // Start is called before the first frame update
    private void Awake()
    { 
        tilemap = GetComponent<Tilemap>();
    }

    public void GenerateMap()
    {
        for (int i = -halfSizeY; i < +halfSizeY; ++i)
        {
            for (int j = -halfSizeX; j < +halfSizeX; ++j)
            {
                int rand = Random.Range(0, groundTiles.Length);
                tilemap.SetTile(new Vector3Int(i,j,0),groundTiles[rand]);
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
