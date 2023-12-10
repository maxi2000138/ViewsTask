using UnityEngine;
using Zenject;

public class MenuButtonsInstaller : MonoInstaller
{
    [SerializeField] private CustomButton _exitToStartSceneButton;
    [SerializeField] private Transform _levelButtonsTransform;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MenuButton>().AsSingle();
        Container.Bind<StartSceneButtonLogic>().AsTransient();
        
        Container.Bind<IButton>().To<StartSceneButtonLogic>().WhenInjectedIntoInstance(_exitToStartSceneButton);
    }
}