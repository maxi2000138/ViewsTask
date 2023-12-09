using CodeBase.Infrastructure;
using CodeBase.Logic;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private DataDB _dataDB;
    [SerializeField] private ScenesConfig _scenesConfig;

    [SerializeField] private DataContainersIds _dataContainersIds;
    [SerializeField] private MusicPlayer _musicPlayer;
    [SerializeField] private LoadingCurtain _loadingCurtains;

    public override void InstallBindings()
    {
        Container.Bind<DataDB>().FromInstance(_dataDB).AsSingle();
        Container.Bind<ScenesConfig>().FromInstance(_scenesConfig).AsSingle();

        Container.Bind<TweenCore>().AsSingle();
        Container.BindInterfacesAndSelfTo<SettingsSoundMusicService>().AsSingle();
        Container.Bind<DataContainersIds>().FromInstance(_dataContainersIds).AsSingle();
        Container.Bind<MusicPlayer>().FromInstance(_musicPlayer).AsSingle();
        Container.Bind<ILoadingCurtain>().To<LoadingCurtain>().FromInstance(_loadingCurtains).AsSingle();
        Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
        Container.Bind<SceneLoaderWithCurtains>().AsSingle();
        Container.Bind<IDataContainersStorage>().To<DataContainersStorage>().AsSingle();
    }
}
