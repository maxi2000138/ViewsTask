public class RewardButtonLogic : IButton
{
    
    private readonly StartPopupService _startPopupService;

    public RewardButtonLogic(StartPopupService startPopupService)
    {
        _startPopupService = startPopupService;
    }
    
    public void OnClick()
    {
        _startPopupService.ShowRewardPopup();
    }
}