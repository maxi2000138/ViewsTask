using System;

[Serializable]
public class PopupData
{
    public BasePopup Popup { get; }
    public IPopupPresenter PopupPresenter { get; }

    public PopupData(BasePopup popup, IPopupPresenter popupPresenter)
    {
        Popup = popup;
        PopupPresenter = popupPresenter;
    }
}