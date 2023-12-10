using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class MenuInitState : IEnterState
{
    private readonly IDataContainersStorage _dataContainersStorage;
    private readonly DataContainersIds _dataContainersIds;
    private readonly LevelButtonsContainer _levelButtonsContainer;
    
    public MenuInitState(IDataContainersStorage dataContainersStorage, DataContainersIds dataContainersIds, LevelButtonsContainer levelButtonsContainer)
    {
        _dataContainersStorage = dataContainersStorage;
        _dataContainersIds = dataContainersIds;
        _levelButtonsContainer = levelButtonsContainer;
    }
    
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        _levelButtonsContainer.Initialize();
        _levelButtonsContainer.UpdateButtonsState(_dataContainersStorage.GetContainer<int>(_dataContainersIds.LastCompletedLVL).Data);
        gameStateMachine.Enter<MenuLocalizationState>();
        return UniTask.CompletedTask;
    }
}
