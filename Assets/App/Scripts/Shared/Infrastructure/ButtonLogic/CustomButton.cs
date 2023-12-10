using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class CustomButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Config _config;
    
    [InjectOptional] private IButton _buttonLogic;
    private MusicPlayer _musicPlayer;
    private bool _enabled;


    [Inject]
    private void Construct(MusicPlayer musicPlayer)
    {
        _musicPlayer = musicPlayer;
        _enabled = _button.enabled;
    }
    
    private void OnEnable()
    {
        AddListener(PlaySoundOnClick);

        if(_buttonLogic != null)
            AddListener(_buttonLogic.OnClick);
        
        if(_config.PunchScaleOnClick)
            AddListener(DisableAndScaleOnClick);
    }

    private void OnDisable()
    {
        RemoveListener(PlaySoundOnClick);

        if(_buttonLogic != null)
            RemoveListener(_buttonLogic.OnClick);

        if(_config.PunchScaleOnClick)
            RemoveListener(DisableAndScaleOnClick);
    }

    public void AddListener(UnityAction listener) => _button.onClick.AddListener(listener);
    public void RemoveListener(UnityAction listener) => _button.onClick.RemoveListener(listener);
    public void EnableButton()
    {
        _enabled = true;
        _button.interactable = true;
    }

    public void DisableButton()
    {
        _enabled = false;
        _button.interactable = false;
    }


    private async void DisableAndScaleOnClick()
    {
        _button.interactable = false;
        await _button.transform.DOPunchScale(new Vector3(1f,1f,1f) * _config.ClickScale, _config.Duration).Play().ToUniTask();
        
        if(_enabled)
            _button.interactable = true;
    }
    
    public void PlaySoundOnClick()
    {
        _musicPlayer.PLayClickSound();
    }
        
    
    [Serializable]
    private class Config
    {
        public bool PunchScaleOnClick = true;
        public float ClickScale = 0.1f;
        public float Duration = 0.2f;
    }
}
