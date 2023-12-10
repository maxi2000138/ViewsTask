using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DayRewardPopup : BasePopup<bool>
{
    [SerializeField] private TMP_Text _ticketsAmountText;
    [SerializeField] private CustomButton _hideButton;

    private IDayRewardPopupPresenter _dayRewardPopupPresenter;

    protected override void OnOpen(object args)
    {
        if (args is not IDayRewardPopupPresenter dayRewardPopupPresenter)
        {
            Debug.LogError("Day reward popup presenter expected!");
            throw new Exception();
        }

        _dayRewardPopupPresenter = dayRewardPopupPresenter;
        
        _ticketsAmountText.text = $"X{_dayRewardPopupPresenter.GetTicketsAmount()}";
        _hideButton.AddListener(SetResult);
    }

    protected override UniTask OnHide()
    {
        _hideButton.RemoveListener(SetResult);
        return UniTask.CompletedTask;
    }
    
    private void SetResult() => SetPopUpResult(true);

}
