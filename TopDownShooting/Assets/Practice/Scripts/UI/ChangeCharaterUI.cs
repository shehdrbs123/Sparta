using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChangeCharaterUI : BaseUI
{
    [SerializeField] private CharacterJob[] Jobs;

    [SerializeField] private Image currentSelected;
    [SerializeField] private Button[] Buttons;
    private int currentSelectedIdx = 0;
    
    private void Start()
    {
        Buttons[0].onClick.AddListener(selectCharacter1);
        Buttons[1].onClick.AddListener(selectCharacter2);
        Buttons[2].onClick.AddListener(selectCharacter3);
        Buttons[3].onClick.AddListener(selectCharacter4);
        Buttons[4].onClick.AddListener(ChangeCharacter);
        Buttons[4].onClick.AddListener(InputActiveToggle);
    }

    public void selectCharacter1()
    {
        currentSelectedIdx = 0;
        currentSelected.sprite = Jobs[currentSelectedIdx].MainImage;
    }
    public void selectCharacter2()
    {
        currentSelectedIdx = 1;
        currentSelected.sprite = Jobs[currentSelectedIdx].MainImage;
    }
    public void selectCharacter3()
    {
        currentSelectedIdx = 2;
        currentSelected.sprite = Jobs[currentSelectedIdx].MainImage;
    }
    public void selectCharacter4()
    {
        currentSelectedIdx = 3;
        currentSelected.sprite = Jobs[currentSelectedIdx].MainImage;
    }
    
    public void ChangeCharacter()
    {
        GameObject player = GameManager.Instance.GetPlayer();
        Animator anim = player.GetComponentInChildren<Animator>();
        anim.runtimeAnimatorController = Jobs[currentSelectedIdx].animator;
        gameObject.SetActive(false);
        
    }
}
