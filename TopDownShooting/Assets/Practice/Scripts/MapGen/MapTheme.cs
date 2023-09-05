using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "MapTheme", menuName = "ScriptableObject/MapTheme", order = 2)]
[Serializable]
public class MapTheme : ScriptableObject
{
    [Header("바닥")] 
    [SerializeField] public TileBase[] _ground;
    [SerializeField] public int[] _groundPossibility;
    [SerializeField] public TileBase[] _groundDeco;
    [SerializeField] public int[] _groundDecoPossibility;
    [SerializeField] public int groundOrderInLayer;
    [Space]
    [Header("벽")]
    [SerializeField] public TileBase[] _walls;
    [SerializeField] public int[] _wallsPossiability;
    [SerializeField] public TileBase[] _wallGroundEdge;
    [SerializeField] public int[] _wallGroundEdgePossibiliity;
    [SerializeField] public TileBase[] _wallDeco;
    [SerializeField] public int[] _wallsDecoPossibility;
    [SerializeField] public TileBase[] _wallLeftCorners;
    [SerializeField] public int[] _wallLeftCornersPossibility;
    [SerializeField] public TileBase[] _wallRightCorners;
    [SerializeField] public int[] _wallRightCornersPossibility;
    
    [Space]
    [Header("위쪽 벽")]
    [SerializeField] public TileBase[] _wallTopLeft;
    [SerializeField] public int[] _wallTopLeftPossibility;
    [SerializeField] public TileBase[] _wallTopRight;
    [SerializeField] public int[] _wallTopRightPossibility;
    [SerializeField] public TileBase[] _wallTopMiddle;
    [SerializeField] public int[] _wallTopMiddlePossibility;
    [Space]
    [Header("왼쪽 벽")]
    [SerializeField] public TileBase[] _wallLeftSide;
    [SerializeField] public int[] _wallLeftSidePossibility;
    [Header("오른쪽 벽")]
    [SerializeField] public TileBase[] _wallRightSide;
    [SerializeField] public int[] _wallRightSidePossibility;
    [Space]
    [Header("아랫쪽 벽")]
    [SerializeField] public TileBase[] _wallBottomTopLeftCorner;
    [SerializeField] public int[] _wallBottomTopLeftCornerPossibility;
    [SerializeField] public TileBase[] _wallBottomTopRightCorner;
    [SerializeField] public int[] _wallBottomTopRightCornerPossibility;
    [SerializeField] public TileBase[] _wallBottomLeft;
    [SerializeField] public int[] _wallBottomLeftPossibility;
    [SerializeField] public TileBase[] _wallBottomRight;
    [SerializeField] public int[] _wallBottomRightPossibility;
    [Space]
    [Header("벽 OrderInLayer")]
    [SerializeField] public int _backDesignOrderInLayer;
    [SerializeField] public int _foreDesignOrderInLayer;
}
