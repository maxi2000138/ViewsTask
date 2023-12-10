public class ShopButtonLogic : IButton
{
    private readonly StartPopupService _startPopupService;

    public ShopButtonLogic(StartPopupService startPopupService)
    {
        _startPopupService = startPopupService;
    }
    
    public void OnClick()
    {
        _startPopupService.ShowShopPopup();
    }
}
