using UnityEngine;
using Zenject;

public class StartPopupsInstaller : MonoInstaller
{
    [SerializeField] private BasePopup _settingsPopup;

    public override void InstallBindings()
    {
        Container.Bind<StartPopupService>().AsSingle().NonLazy();
        
        PopupInstallerExtensions.BinPopup<ISettingsPopupPresenter, SettingsPopupPresenter>(Container, _settingsPopup);
    }
}