using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Random = Unity.Mathematics.Random;

[ExecuteInEditMode]
public class MapTool : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]MapTheme MapTheme;
    
    
    [Header("바닥")] 
    private TilePersent[] _ground;
    private TilePersent[] _groundDeco;
    private int groundOrderInLayer;
    [Space]
    [Header("벽")]
    private TilePersent[] _walls;
    private TilePersent[] _wallDeco;
    private TilePersent[] _wallLeftCorners;
    private TilePersent[] _wallRightCorners;
    private TilePersent[] _wallGroundEdge;
    
    [Space]
    [Header("위쪽 벽")]
    private TilePersent[] _wallTopLeft;
    private TilePersent[] _wallTopRight;
    private TilePersent[] _wallTopMiddle;
    [Space]
    [Header("왼쪽 벽")]
    private TilePersent[] _wallLeftSide;
    [Header("오른쪽 벽")]
    private TilePersent[] _wallRightSide;
    [Space]
    [Header("아랫쪽 벽 위")]
    private TilePersent[] _wallBottomTopMiddle;
    private TilePersent[] _wallBottomTopLeftCorner;
    private TilePersent[] _wallBottomTopRightCorner;
    private TilePersent[] _wallBottomLeft;
    private TilePersent[] _wallBottomRight;
    [Space]
    [Header("벽 OrderInLayer")]
    private int _backDesignOrderInLayer;
    private int _foreDesignOrderInLayer;
    [Space] 
    [Header("벽을 만들지 말지")] 
    [SerializeField] private bool MakeTop=true;
    [SerializeField] private bool MakeBottom=true;
    [SerializeField] private bool MakeLeft=true;
    [SerializeField] private bool MakeRight=true;

    [Space] 
    [Header("벽 높이")] 
    [SerializeField] private int UpperWallLength = 1;
    [SerializeField] private int LowerWallLength = 1;
    
    [Header("맵 가로 세로의 절반을 입력해주세요")]
    [SerializeField] private Vector2 _mapHalfSize;

    [SerializeField] private int seed;
    
    private GameObject _gridObject;
    private Transform _groundTransform;

    private Random rand;

    private int xStart;
    private int xEnd;
    private int yStart;
    private int yEnd;

    public void UpdateTilePersents()
    {
        SettingTilePercents();
    }
    
    public void MakeMap()
    {
        if (IsTilesOk())
        {
            rand.InitState((uint)seed);
            SettingMapRoot();
            SetSize();
            MakeGround();
            MakeBackDesign();
            MakeForeDesign();
            MakeCollision();
        }
        else
        {
            Console.WriteLine("타일 목록에 최소 한 개 이상의 타일을 모두 넣어주세요");
        }
    }

    private void SettingTilePercents()
    {
        SetPercent(out _ground,MapTheme._ground,MapTheme._groundPossibility);
        SetPercent(out _groundDeco,MapTheme._groundDeco,MapTheme._groundDecoPossibility);
        
        SetPercent(out _walls,MapTheme._walls,MapTheme._wallsPossiability);
        SetPercent(out _wallDeco,MapTheme._wallDeco,MapTheme._wallsDecoPossibility);
        SetPercent(out _wallLeftCorners,MapTheme._wallLeftCorners,MapTheme._wallLeftCornersPossibility);
        SetPercent(out _wallRightCorners,MapTheme._wallRightCorners,MapTheme._wallRightCornersPossibility);
        SetPercent(out _wallGroundEdge,MapTheme._wallGroundEdge,MapTheme._wallGroundEdgePossibiliity);
        
        SetPercent(out _wallTopLeft,MapTheme._wallTopLeft,MapTheme._wallTopLeftPossibility);
        SetPercent(out _wallTopRight,MapTheme._wallTopRight,MapTheme._wallTopRightPossibility);
        SetPercent(out _wallTopMiddle,MapTheme._wallTopMiddle,MapTheme._wallTopMiddlePossibility);
        
        SetPercent(out _wallLeftSide,MapTheme._wallLeftSide,MapTheme._wallLeftSidePossibility);
        SetPercent(out _wallRightSide,MapTheme._wallRightSide,MapTheme._wallRightSidePossibility);
        SetPercent(out _wallBottomTopLeftCorner,MapTheme._wallBottomTopLeftCorner,MapTheme._wallBottomTopLeftCornerPossibility);
        SetPercent(out _wallBottomTopRightCorner,MapTheme._wallBottomTopRightCorner,MapTheme._wallBottomTopRightCornerPossibility);
        SetPercent(out _wallBottomLeft,MapTheme._wallBottomLeft,MapTheme._wallBottomLeftPossibility);
        SetPercent(out _wallBottomRight,MapTheme._wallBottomRight,MapTheme._wallBottomRightPossibility);
    }

    private void SetPercent(out TilePersent[] tilep,TileBase[] tiles, int[] possibility)
    {
        tilep = new TilePersent[tiles.Length];
        for (int i = 0; i < tiles.Length; ++i)
        {
            tilep[i] = new TilePersent(tiles[i], possibility[i]);
        }
    }

    private void SetSize()
    {
        xStart = (int)-_mapHalfSize.x;
        xEnd = (int)_mapHalfSize.x;
        yStart = (int)-_mapHalfSize.y;
        yEnd = (int)_mapHalfSize.y;
    }

    private bool IsTilesOk()
    {
        return true;
    }

    private void SettingMapRoot()
    {
        if (!_gridObject)
        {
            _gridObject = GameObject.Find("MapRoot");
            if (!_gridObject)
            {
                CreateMapRoot();
            }
        }
    }

    private void CreateMapRoot()
    {
        _gridObject = new GameObject("MapRoot");
        _gridObject.AddComponent<Grid>();
    }
    
    private GameObject MakeGround()
    {
        GameObject ground = new GameObject("Ground");
        Tilemap tilemap;
        TilemapRenderer tilemapRenderer;
        AddTilemapComponent(ground,out tilemap, out tilemapRenderer);
        _groundTransform = ground.transform;
        ground.transform.SetParent(_gridObject.transform);
        
        DrawGround(tilemap);

        tilemapRenderer.sortingOrder = MapTheme.groundOrderInLayer;

        return ground;
    }

    private void DrawGround(Tilemap tilemap)
    {
        for (int i = yStart; i < yEnd; ++i)
        {
            DrawTileLine(xStart,xEnd,true,i,tilemap,_ground);
        }
    }

    private void MakeBackDesign()
    {
        if (!MakeTop)
            return;
        GameObject backSign = new GameObject("backSign");
        Tilemap tilemap;
        TilemapRenderer tilemapRenderer;
        
        AddTilemapComponent(backSign,out tilemap,out tilemapRenderer);
        backSign.transform.SetParent(_groundTransform);
        DrawTopWalls(tilemap);
        
        tilemapRenderer.sortingOrder = MapTheme._backDesignOrderInLayer;
    }

    private void DrawTopWalls(Tilemap tilemap)
    {
    
        for (int i = 0; i < UpperWallLength; ++i)
        {
            DrawTileLine(xStart,xEnd,true,yEnd+i,tilemap,_walls);
        }
        DrawTileLine(xStart+1,xEnd-1,true,yEnd-1,tilemap,_wallGroundEdge);
                        
        DrawTileLine(xStart,xEnd,true,yEnd+UpperWallLength,tilemap,_wallTopMiddle);

        if (MakeLeft)
        {
            for (int i = 0; i < UpperWallLength; ++i)
                tilemap.SetTile(new Vector3Int(xStart,yEnd+i),GetTile(_wallLeftCorners));
            tilemap.SetTile(new Vector3Int(xStart,yEnd+UpperWallLength),GetTile(_wallTopLeft));
        }

        if (MakeRight)
        {
            for (int i = 0; i < UpperWallLength; ++i)
                tilemap.SetTile(new Vector3Int(xEnd-1,yEnd+i),GetTile(_wallRightCorners));
            tilemap.SetTile(new Vector3Int(xEnd-1,yEnd+UpperWallLength),GetTile(_wallTopRight));
            
        }
    }

    private void MakeForeDesign()
    {
        GameObject foreSign = new GameObject("foreSign");
        Tilemap tilemap;
        TilemapRenderer tilemapRenderer;
        
        AddTilemapComponent(foreSign,out tilemap, out tilemapRenderer);
        foreSign.transform.SetParent(_groundTransform);
        if (MakeLeft)
            DrawLeft(tilemap);

        if (MakeRight)
            DrawRight(tilemap);

        if (MakeBottom)
            DrawBottom(tilemap);
        tilemapRenderer.sortingOrder =MapTheme._foreDesignOrderInLayer;
    }

    private void DrawBottom(Tilemap tilemap)
    {
        for (int i = 0; i < LowerWallLength; ++i)
            DrawTileLine(xStart,xEnd,true,yStart+i,tilemap,_walls);            
        DrawTileLine(xStart,xEnd,true,yStart+LowerWallLength,tilemap,_wallTopMiddle);

        if (MakeLeft)
        {
            for (int i = 0; i < LowerWallLength; ++i)
                tilemap.SetTile(new Vector3Int(xStart,yStart+i),GetTile(_wallBottomLeft));
            tilemap.SetTile(new Vector3Int(xStart,yStart+LowerWallLength),GetTile(_wallBottomTopLeftCorner));
            
        }

        if (MakeLeft)
        {
            for(int i=0;i<LowerWallLength;++i)
                tilemap.SetTile(new Vector3Int(xEnd-1,yStart+i),GetTile(_wallBottomRight));    
            tilemap.SetTile(new Vector3Int(xEnd-1,yStart+LowerWallLength),GetTile(_wallBottomTopRightCorner));
        }
            
    }

    private void DrawRight(Tilemap tilemap)
    {
        DrawTileLine(yStart,yEnd,false,xEnd-1,tilemap,_wallRightSide);
    }

    private void DrawLeft(Tilemap tilemap)
    {
        DrawTileLine(yStart,yEnd,false,xStart,tilemap,_wallLeftSide);
    }

    private void MakeCollision()
    {
        GameObject collision = new GameObject("Collision");
        Tilemap tilemap;
        TilemapRenderer tilemapRenderer;
        AddTilemapComponent(collision,out tilemap, out tilemapRenderer);
        collision.transform.SetParent(_groundTransform);
        collision.AddComponent<TilemapCollider2D>();
        tilemap.color = Color.clear;

        if (MakeTop)
            for (int i = 0; i < LowerWallLength; ++i)
                DrawTileLine(xStart, xEnd, true, yEnd, tilemap,_walls);

        if (MakeBottom)
        {
            DrawTileLine(xStart,xEnd,true,yStart,tilemap,_wallTopMiddle);
            DrawTileLine(xStart,xEnd,true,yStart-1,tilemap,_walls);
        }
        
        if (MakeLeft)
        {
            DrawLeft(tilemap);
            tilemap.SetTile(new Vector3Int(xStart,yStart),GetTile(_wallBottomTopLeftCorner));
        }


        if (MakeRight)
        {
            DrawRight(tilemap);  
            tilemap.SetTile(new Vector3Int(xEnd-1,yStart),GetTile(_wallBottomTopRightCorner));
        }
 

        
    }
    private void AddTilemapComponent(GameObject obj, out Tilemap tilemap, out TilemapRenderer renderer)
    {
        tilemap = obj.AddComponent<Tilemap>();
        renderer = obj.AddComponent<TilemapRenderer>();
    }

    private TileBase GetTile(TilePersent[] tiles)
    {
        if (tiles.Length == 1)
            return tiles[0].tile;
        
        int totalPercent = 0;
        int restPercent=0;
        Array.ForEach(tiles,tiles =>
        {
            if (tiles.possiablity == 0) tiles.possiablity= 1;
            totalPercent += tiles.possiablity;
        });

        int ran = rand.NextInt(0, totalPercent);
        for (int i=0;i<tiles.Length; ++i)
        {
            restPercent += tiles[i].possiablity;
            if (restPercent > ran)
                return  tiles[i].tile;
        }
        return null;
    }

    private void DrawTileLine(int start, int end,bool isXloop, int pos, Tilemap tilemap,TilePersent[] tiles)
    {
        for (int i = start; i < end; i++)
        {
            int x = i;
            int y = pos;
            if (!isXloop)
            {
                x = pos;
                y = i;
            }
            tilemap.SetTile(new Vector3Int(x,y),GetTile(tiles));
        }
    }
}

[Serializable]
public class TilePersent
{
    public TilePersent(TileBase tile, int possiablity)
    {
        this.tile = tile;
        this.possiablity = possiablity;
    }
    public TileBase tile;
    [Range(1,1000000)]
    public int possiablity=1;
}