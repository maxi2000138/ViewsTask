using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class LevelButton : LevelButtonBase
{
    [SerializeField] private TMP_Text _levelButtonText;
    [SerializeField] private int _levelNumber = 1;
    
    public override void Initialize(int levelNumber)
    {
        _levelNumber = levelNumber;
    }

    [Button]
    public override void SetLVLName()
    {
        _levelButtonText.text = _levelNumber.ToString();
    }
}
