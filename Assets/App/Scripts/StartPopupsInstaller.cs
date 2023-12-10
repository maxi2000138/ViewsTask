using UnityEngine;
using Zenject;

public class StartPopupsInstaller : MonoInstaller
{
    [SerializeField] private BasePopup _settingsPopup;
    [SerializeField] private BasePopup _rewardPopup;
    [SerializeField] private BasePopup _shopPopup;
    [SerializeField] private BasePopup _dayRewardPopup;

    public override void InstallBindings()
    {
        Container.Bind<StartPopupService>().AsSingle().NonLazy();
        
        PopupInstallerExtensions.BindPopup<ISettingsPopupPresenter, SettingsPopupPresenter>(Container, _settingsPopup);
        PopupInstallerExtensions.BindPopup<IRewardPopupPresenter, RewardPopupPresenter>(Container, _rewardPopup);
        PopupInstallerExtensions.BindPopup<IShopPopupPresenter, ShopPopupPresenter>(Container, _shopPopup);
        PopupInstallerExtensions.BindPopup<IDayRewardPopupPresenter, DayRewardPopupPresenter>(Container, _dayRewardPopup);
    }
}