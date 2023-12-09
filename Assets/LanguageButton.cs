using System.Collections.Generic;
using Zenject;

public class LanguageButton : IButton, IInitializable
{
    private int _currentLanguage = 0;
    private List<string> _languagesOrder;
    private IDataContainer<string> _languageContainer;
    
    private readonly IDataContainersStorage _dataContainersStorage;
    private readonly DataContainersIds _dataContainersIds;
    private readonly LanguagesIds _languagesIds;
    private readonly Localizer _localizer;


    public LanguageButton(IDataContainersStorage dataContainersStorage, DataContainersIds dataContainersIds, LanguagesIds languagesIds, Localizer localizer)
    {
        _dataContainersStorage = dataContainersStorage;
        _dataContainersIds = dataContainersIds;
        _languagesIds = languagesIds;
        _localizer = localizer;
    }

    public void Initialize()
    {
        _languageContainer = _dataContainersStorage.GetContainer<string>(_dataContainersIds.CurrentLanguage);
        SetLanguagesOrder();
        _currentLanguage = _languagesOrder.FindIndex(language => language == _languageContainer.Data);
    }

    public void OnClick()
    {
        _currentLanguage++;
        
        if (_currentLanguage >= _languagesOrder.Count)
            _currentLanguage = 0;
        
        _languageContainer.Data = _languagesOrder[_currentLanguage];
        _localizer.LocalizeAllText();   
    }

    private void SetLanguagesOrder()
    {
        _languagesOrder = new()
        {
            _languagesIds.EnglishLanguage,
            _languagesIds.RussianLanguage,
        };
    }
}
