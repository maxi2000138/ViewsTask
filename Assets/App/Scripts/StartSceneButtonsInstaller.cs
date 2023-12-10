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
        Container.Bind(typeof(IInitializable), typeof(LanguageButton)).To<LanguageButton>().AsSingle();
        
        Container.Bind<IButton>().To<PlayButtonLogic>().WhenInjectedIntoInstance(_playButton);
        Container.Bind<IButton>().To<ShopButtonLogic>().WhenInjectedIntoInstance(_shopButton);
        Container.Bind<IButton>().To<SettingsButtonLogic>().WhenInjectedIntoInstance(_settingsButton);
        Container.Bind<IButton>().To<RewardButtonLogic>().WhenInjectedIntoInstance(_rewardButton);
    }
}