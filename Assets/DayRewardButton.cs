public class DayRewardButton
{
    private readonly IDataContainersStorage _dataContainersStorage;
    private readonly DataContainersIds _dataContainersIds;
    private readonly StartPopupService _startPopupService;

    public DayRewardButton(IDataContainersStorage dataContainersStorage, DataContainersIds dataContainersIds, StartPopupService startPopupService)
    {
        _dataContainersStorage = dataContainersStorage;
        _dataContainersIds = dataContainersIds;
        _startPopupService = startPopupService;
    }
    
    public void OnClick(int reward)
    {
        _dataContainersStorage.GetContainer<int>(_dataContainersIds.CurrentReward).Data = reward;
        _dataContainersStorage.GetContainer<int>(_dataContainersIds.Money).Data += reward;
        _startPopupService.ShowDayRewardPopup();
    }
}