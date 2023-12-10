using UnityEngine;
using Zenject;

public class MenuServicesInstaller : MonoInstaller
{
    [SerializeField] private LevelButtonsContainer _levelButtonsContainer;

    public override void InstallBindings()
    {
        Container.Bind<LevelButtonsContainer>().FromInstance(_levelButtonsContainer).AsSingle();
    }
}
