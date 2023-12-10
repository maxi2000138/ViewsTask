using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ShopPopup : BasePopup<bool>
{
    [SerializeField] private CustomButton _hideButton;
    
    private IShopPopupPresenter _shopPopupPresenter;

    protected override void OnOpen(object args)
    {
        if (args is not IShopPopupPresenter shopPopupPresenter)
        {
            Debug.LogError("Shop popup presenter expected!");
            throw new Exception();
        }

        _shopPopupPresenter = shopPopupPresenter;
        
        _hideButton.AddListener(SetResult);
    }

    protected override UniTask OnHide()
    {
        _hideButton.RemoveListener(SetResult);

        return UniTask.CompletedTask;
    }
    
    private void SetResult() => SetPopUpResult(true);
}
