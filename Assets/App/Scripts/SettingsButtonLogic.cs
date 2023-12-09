public class SettingsButtonLogic : IButton
{
    private readonly StartPopupService _startPopupService;

    public SettingsButtonLogic(StartPopupService startPopupService)
    {
        _startPopupService = startPopupService;
    }

    public void OnClick()
    {
        _startPopupService.ShowSettingsPopup();
    }
}