using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private DataDB _dataDB;
    public override void InstallBindings()
    {
        Container.Bind<DataDB>().FromInstance(_dataDB).AsSingle();
        Container.Bind<IDataContainersStorage>().To<DataContainersStorage>().AsSingle();
    }
}
