using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class LevelButton : LevelButtonBase
{
    [SerializeField] private TMP_Text _levelButtonText;
    [field:SerializeField] public CustomButton Button { get; private set; }
    [field: SerializeField] public int LevelNumber {get; private set; }
    
    public override void Initialize(int levelNumber)
    {
        LevelNumber = levelNumber;
    }

    [Button]
    public override void SetLVLName()
    {
        _levelButtonText.text = LevelNumber.ToString();
    }
}
