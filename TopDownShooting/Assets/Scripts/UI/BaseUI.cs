using System;
using System.Collections;
using System.Collections.Generic;
using Practice.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseUI : MonoBehaviour
{
    protected static GameDataManager _gameDataManager;
    protected static UIManager _uiManager;
    [SerializeField] protected bool isIgnoreInput; 
    protected virtual void Awake()
    {
        _gameDataManager = GameManager.Instance.GameDataManager;
        _uiManager = GameManager.Instance.UIManager;
    }

    protected void OnEnable()
    {
        if(_uiManager && isIgnoreInput)
            _uiManager.EnablePanel(gameObject);
    }

    protected void OnDisable()
    {
        if(_uiManager && isIgnoreInput)
            _uiManager.DisablePanel(gameObject);
    }
}
