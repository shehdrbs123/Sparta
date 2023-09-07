using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopUI : MonoBehaviour
{
    private UIManager _uiManager;
    [SerializeField] private Button ChangeName;
    [SerializeField] private Button ChangeCharacter;
    [SerializeField] private Button ShowLoginList;

    private GameObject _nameUI;
    private void Awake()
    {
        ChangeName.onClick.AddListener(OnClickChangeName);
        ChangeCharacter.onClick.AddListener(OnClickChangeCharacter);
        ShowLoginList.onClick.AddListener(OnClickShowLoginList);
    }

    private void Start()
    {
        _uiManager = GameManager.Instance.UIManager;
        _nameUI = _uiManager.GetUI("NameUI");
        _nameUI.SetActive(false);
    }

    public void OnClickChangeName()
    {
        _nameUI.SetActive(true);
    }

    public void OnClickChangeCharacter()
    {
        
    }

    public void OnClickShowLoginList()
    {
        
    }
}
