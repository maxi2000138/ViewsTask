using Zenject;

public class MenuButton : IInitializable
{
    private IDataContainer<int> _lastLvlContainer;
    private IDataContainer<int> _levelsAmountContainer;
    private readonly IDataContainersStorage _dataContainersStorage;
    private readonly DataContainersIds _dataContainersIds;
    private readonly LevelButtonsContainer _levelButtonsContainer;

    public MenuButton(IDataContainersStorage dataContainersStorage, DataContainersIds dataContainersIds, LevelButtonsContainer levelButtonsContainer)
    {
        _dataContainersStorage = dataContainersStorage;
        _dataContainersIds = dataContainersIds;
        _levelButtonsContainer = levelButtonsContainer;
    }

    public void Initialize()
    {
        _lastLvlContainer = _dataContainersStorage.GetContainer<int>(_dataContainersIds.LastCompletedLVL);
        _levelsAmountContainer = _dataContainersStorage.GetContainer<int>(_dataContainersIds.LevelsAmount);
    }
    
    public void OnClick(int lvl)
    {
        if(lvl == _lastLvlContainer.Data+1 && lvl < _levelsAmountContainer.Data) 
            _lastLvlContainer.Data++;
        
        _levelButtonsContainer.UpdateButtonsState(_lastLvlContainer.Data);
    }
}