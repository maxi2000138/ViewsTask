using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Config _config;

    
    private void Start()
    {
        if(_config.PunchScaleOnClick)
            _button.onClick.AddListener(DisableAndScaleOnClick);
    }

    private async void DisableAndScaleOnClick()
    {
        _button.interactable = false;
        await _button.transform.DOPunchScale(new Vector3(1f,1f,1f) * _config.ClickScale, _config.Duration).Play().ToUniTask();
        _button.interactable = true;
    }
    
    [Serializable]
    private class Config
    {
        public bool PunchScaleOnClick = true;
        public float ClickScale = 0.1f;
        public float Duration = 0.2f;
    }
}
