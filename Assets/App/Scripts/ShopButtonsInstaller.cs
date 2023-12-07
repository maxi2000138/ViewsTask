using UnityEngine;
using Zenject;

public class ShopButtonsInstaller : MonoInstaller
{
    [SerializeField] private CustomButton _startSceneButton;

    public override void InstallBindings()
    {
        Container.Bind<IButton>().To<StartSceneButtonLogic>().WhenInjectedIntoInstance(_startSceneButton);
    }
}
