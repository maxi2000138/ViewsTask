public class DayRewardPopupPresenter : IDayRewardPopupPresenter
{
    private readonly IDataContainersStorage _dataContainersStorage;
    private readonly DataContainersIds _dataContainersIds;

    public DayRewardPopupPresenter(IDataContainersStorage dataContainersStorage, DataContainersIds dataContainersIds)
    {
        _dataContainersStorage = dataContainersStorage;
        _dataContainersIds = dataContainersIds;
    }
    
    public int GetTicketsAmount() => _dataContainersStorage.GetContainer<int>(_dataContainersIds.CurrentReward).Data;
}