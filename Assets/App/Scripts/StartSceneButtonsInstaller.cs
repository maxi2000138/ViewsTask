using UnityEngine;
using Zenject;

public class StartSceneButtonsInstaller : MonoInstaller
{
    [SerializeField] private CustomButton _playButton;
    [SerializeField] private CustomButton _shopButton;
    [SerializeField] private CustomButton _rewardButton;
    [SerializeField] private CustomButton _settingsButton;
    
    public override void InstallBindings()
    {
        Container.Bind<IButton>().To<PlayButtonLogic>().WhenInjectedIntoInstance(_playButton);
        Container.Bind<IButton>().To<ShopButtonLogic>().WhenInjectedIntoInstance(_shopButton);
        Container.Bind<IButton>().To<DefaultButtonLogic>().WhenInjectedIntoInstance(_rewardButton);
        Container.Bind<IButton>().To<DefaultButtonLogic>().WhenInjectedIntoInstance(_settingsButton);
    }
}