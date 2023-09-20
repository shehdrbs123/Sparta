using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ConfirmUI : BaseUI
{
    [SerializeField] private TMP_Text content;
    [SerializeField] private Button confirmButton;

    private void Start()
    {   
        confirmButton.onClick.AddListener(OnClickConfirm);
    }

    private void OnClickConfirm()
    {
        gameObject.SetActive(false);        
    }

    public void ShowConfirmUI(string text)
    {
        content.text = text;
        content.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
}
