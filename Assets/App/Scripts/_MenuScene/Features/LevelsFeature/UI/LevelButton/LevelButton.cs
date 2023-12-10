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
    [SerializeField] private GameObject _closedObject;
    [field:SerializeField] public CustomButton Button { get; private set; }
    [field: SerializeField] public int LevelNumber {get; private set; }
    
    private MenuButton _menuButton;

    [Inject]
    private void Construct(MenuButton menuButton)
    {
        _menuButton = menuButton;
        Button.AddListener(OnClick);
    }
    
    public override void Initialize(int levelNumber)
    {
        LevelNumber = levelNumber;
    }

    private void OnDestroy()
    {
        Button.RemoveListener(OnClick);
    }

    [Button]
    public override void SetLVLName()
    {
        _levelButtonText.text = LevelNumber.ToString();
    }

    private void OnClick() => _menuButton.OnClick(LevelNumber);

    public void SetState(bool isActive)
    {
        if (isActive)
        {
            Button.EnableButton();
            _closedObject.SetActive(false);
        }
        else
        {
            Button.DisableButton();
            _closedObject.SetActive(true);
        }
    }
}
