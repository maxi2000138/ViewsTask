using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class SettingsPopup : BasePopup<bool>
{
    [SerializeField] private CustomButton _musicButton;
    [SerializeField] private CustomButton _soundsButton;
    [SerializeField] private CustomButton _hideButton;
    
    [SerializeField] private SpriteToggle _musicToggle;
    [SerializeField] private SpriteToggle _soundsToggle;
    
    private ISettingsPopupPresenter _settingsPopupPresenter;

    protected override void OnOpen(object args)
    {
        if (args is not ISettingsPopupPresenter settingsPopupPresenter)
        {
            Debug.LogError("Settings popup presenter expected!");
            throw new Exception();
        }

        _settingsPopupPresenter = settingsPopupPresenter;
        _settingsPopupPresenter.Construct(_musicToggle, _soundsToggle);
        
        _settingsPopupPresenter.InitButtons();
        
        _musicButton.AddListener(_settingsPopupPresenter.MusicButtonAction);
        _soundsButton.AddListener(_settingsPopupPresenter.SoundsButtonAction);
        _hideButton.AddListener(SetResult);
        
    }

    protected override UniTask OnHide()
    {
        _musicButton.RemoveListener(_settingsPopupPresenter.MusicButtonAction);
        _soundsButton.RemoveListener(_settingsPopupPresenter.SoundsButtonAction);
        _hideButton.RemoveListener(SetResult);
        
        return UniTask.CompletedTask;
    }
    
    private void SetResult() => SetPopUpResult(true);
}
