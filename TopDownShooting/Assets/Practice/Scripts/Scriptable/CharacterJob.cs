using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterJob", menuName = "ScriptableObject/CharacterJob", order = 3)]
[Serializable]
public class CharacterJob : ScriptableObject
{
    public Sprite MainImage;
    public RuntimeAnimatorController animator;
}
