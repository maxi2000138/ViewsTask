using CodeBase.Infrastructure;
using CodeBase.Logic;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private DataDB _dataDB;
    [SerializeField] private LocaleDB _localeDB;
    [SerializeField] private LanguagesDB _languagesDB;
    [SerializeField] private ScenesConfig _scenesConfig;

    [SerializeField] private DataContainersIds _dataContainersIds;
    [SerializeField] private MusicPlayer _musicPlayer;
    [SerializeField] private LoadingCurtain _loadingCurtains;
    [SerializeField] private LanguagesIds _languagesIds;

    public override void InstallBindings()
    {
        Container.Bind<DataDB>().FromInstance(_dataDB).AsSingle();
        Container.Bind<LocaleDB>().FromInstance(_localeDB).AsSingle();
        Container.Bind<LanguagesDB>().FromInstance(_languagesDB).AsSingle();
        Container.Bind<ScenesConfig>().FromInstance(_scenesConfig).AsSingle();

        Container.Bind<TweenCore>().AsSingle();
        Container.Bind<LocalizationService>().AsSingle();
        Container.BindInterfacesAndSelfTo<SettingsSoundMusicService>().AsSingle();
        Container.Bind<DataContainersIds>().FromInstance(_dataContainersIds).AsSingle();
        Container.Bind<MusicPlayer>().FromInstance(_musicPlayer).AsSingle();
        Container.Bind<LanguagesIds>().FromInstance(_languagesIds).AsSingle();
        Container.Bind<Localizer>().AsSingle().WithArguments(_dataContainersIds.CurrentLanguage);
        Container.Bind<ILoadingCurtain>().To<LoadingCurtain>().FromInstance(_loadingCurtains).AsSingle();
        Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
        Container.Bind<SceneLoaderWithCurtains>().AsSingle();
        Container.Bind<IDataContainersStorage>().To<DataContainersStorage>().AsSingle();
    }
}
