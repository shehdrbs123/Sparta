using System;
using System.Collections;
using System.Collections.Generic;
using Practice.Scripts.Managers;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected static GameDataManager _gameDataManager;
    protected static UIManager _uiManager;
    protected virtual void Awake()
    {
        _gameDataManager = GameManager.Instance.GameDataManager;
        
    }
}
