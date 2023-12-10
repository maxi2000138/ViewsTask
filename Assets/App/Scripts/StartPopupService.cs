using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class StartPopupService : BasePopupService
{
    public StartPopupService(IEnumerable<PopupData> popups) : base(popups)
    { }

    public async UniTask ShowSettingsPopup()
    {
        await ShowNoReturnValuePopup<SettingsPopup>();
    }
    
    public async UniTask ShowShopPopup()
    {
        await ShowNoReturnValuePopup<ShopPopup>();
    }
    
    public async UniTask ShowRewardPopup()
    {
        await ShowNoReturnValuePopup<RewardPopup>();
    }

    private async Task ShowNoReturnValuePopup<T>() where T : BasePopup<bool>
    {
        PopupData popupData = GetPopupData<T>();
        await ((T)popupData.Popup).Show(popupData.PopupPresenter);
        await popupData.Popup.Hide();
    }
}
