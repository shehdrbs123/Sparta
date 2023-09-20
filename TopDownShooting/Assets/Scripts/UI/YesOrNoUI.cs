using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class YesOrNoUI : BaseUI
{
    [SerializeField] private GameObject InfoPanel;
    [SerializeField] private Button YesButton;
    [SerializeField] private Button NoButton;
    [SerializeField] private GameObject TextPanel;

    private UnityAction yesAction;
    private UnityAction noAction;
    private GameObject AddtionalPanel;
    private void Start()
    {
        YesButton.onClick.AddListener(YesAction);
        NoButton.onClick.AddListener(NoAction);
    }

    public void ShowYesOrNoUI(GameObject info, UnityAction Yes, UnityAction No)
    {
        yesAction += Yes;
        noAction += No;
        info.transform.SetParent(InfoPanel.transform);
        AddtionalPanel = InfoPanel;
        gameObject.SetActive(true);
    }
    
    public void ShowYesOrNoUI(string text, UnityAction Yes, UnityAction No)
    {
        yesAction += Yes;
        noAction += No;
        
        TextPanel.SetActive(true);
        TextPanel.GetComponent<TMP_Text>().text = text;
        gameObject.SetActive(true);
    }

    private void YesAction()
    {
        yesAction?.Invoke();
        ResetPanel();
    }

    private void NoAction()
    {
        noAction?.Invoke();
        ResetPanel();
    }

    private void ResetPanel()
    {
        if (AddtionalPanel)
        {
            Destroy(AddtionalPanel);
            AddtionalPanel = null;            
        }
        yesAction -= yesAction;
        noAction -= noAction;
        TextPanel.SetActive(false);
        gameObject.SetActive(false);
    }
}
