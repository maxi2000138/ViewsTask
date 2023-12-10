using System;
using TMPro;
using UnityEngine;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameField;
    [SerializeField] private TMP_Text _costField;
    [SerializeField] private CustomButton _customButton;
    
    private IShopItemUnit _shopItemUnit;
    
    public void SetItemUnit(IShopItemUnit shopItemUnit)
    {
        if(_shopItemUnit != null)
            _customButton.RemoveListener(_shopItemUnit.OnClick);
        
        _shopItemUnit = shopItemUnit;
        _customButton.AddListener(_shopItemUnit.OnClick);
    }
    
    private void OnDestroy()
    {
        _customButton.RemoveListener(_shopItemUnit.OnClick);
    }
    
    public void SetNameText(string text)
    {
        _nameField.text = text;
    }

    public void SetCostText(string text)
    {
        _costField.text = text;
    }
    
    public void EnableBuyButton()
    {
        _customButton.EnableButton();
    }
    
    public void DisableBuyButton()
    {
        _customButton.DisableButton();
    }
}