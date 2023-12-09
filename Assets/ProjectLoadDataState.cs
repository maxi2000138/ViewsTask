using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class ProjectLoadDataState : IEnterState
{
    private readonly IDataContainersStorage _dataContainersStorage;
    private readonly SettingsSoundMusicService _settingsSoundMusicService;

    public ProjectLoadDataState(IDataContainersStorage dataContainersStorage, SettingsSoundMusicService settingsSoundMusicService)
    {
        _dataContainersStorage = dataContainersStorage;
        _settingsSoundMusicService = settingsSoundMusicService;
    }
    
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        _dataContainersStorage.LoadStaticData();
        
        _settingsSoundMusicService.SetMusicState();
        _settingsSoundMusicService.SetSoundsState();
        
        return UniTask.CompletedTask;
    }
}