using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RewardPopup : BasePopup<bool>
{
    [SerializeField] private CustomButton _hideButton;
    
    private IRewardPopupPresenter _rewardPopupPresenter;

    protected override void OnOpen(object args)
    {
        if (args is not IRewardPopupPresenter rewardPopupPresenter)
        {
            Debug.LogError("Shop popup presenter expected!");
            throw new Exception();
        }
        
        _rewardPopupPresenter = rewardPopupPresenter;
        
        _hideButton.AddListener(SetResult);
    }

    protected override UniTask OnHide()
    {
        _hideButton.RemoveListener(SetResult);
        
        return  UniTask.CompletedTask;
    }
    
    private void SetResult() => SetPopUpResult(true);
}
