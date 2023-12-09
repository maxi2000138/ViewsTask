using Sirenix.OdinInspector;
using UnityEngine;

public class LanguagesIds : MonoBehaviour
{
    public string EnglishLanguage => _englishLanguage;
    public string RussianLanguage => _russianLanguage;

    [ValueDropdown(nameof(LanguageTypes))] 
    [SerializeField] private string _englishLanguage;
    
    [ValueDropdown(nameof(LanguageTypes))] 
    [SerializeField] private string _russianLanguage;
    
    
    private ValueDropdownList<string> LanguageTypes()
    {
        var list = new ValueDropdownList<string>();
        Resources.LoadAll<LanguagesDB>("")[0].Languages.ForEach(language => list.Add(language.Name, language.Id));
        return list;
    }
}