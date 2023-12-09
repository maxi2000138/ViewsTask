using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public abstract class BasePopupService
{
    private readonly Dictionary<Type, PopupData> _popups = new();

    public BasePopupService(IEnumerable<PopupData> popups)
    {
        foreach (PopupData popupData in popups)
        {
            _popups.Add(popupData.Popup.GetType(), popupData);
        }
    }
    
    protected PopupData GetPopupData<T>() => _popups[typeof(T)];
}
