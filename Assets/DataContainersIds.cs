using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class DataContainersIds : MonoBehaviour
{
    public string SoundsState => _soundsState;
    public string MusicState => _musicState;
    public string CurrentLanguage => _currentLanguage;
    public string Money => _money;
    public string LastCompletedLVL => _lastCompletedLVL;
    
        
    [ValueDropdown(nameof(DataContainersIDs))] 
    [SerializeField] private string _soundsState;
    
    [ValueDropdown(nameof(DataContainersIDs))] 
    [SerializeField] private string _musicState;

    [ValueDropdown(nameof(DataContainersIDs))] 
    [SerializeField] private string _currentLanguage;
    
    [ValueDropdown(nameof(DataContainersIDs))] 
    [SerializeField] private string _money;
    
    [ValueDropdown(nameof(DataContainersIDs))] 
    [SerializeField] private string _lastCompletedLVL;

    private ValueDropdownList<string> DataContainersIDs()
    {
        var valueDropdownList = new ValueDropdownList<string>();
        Resources.LoadAll<DataDB>(DatabaseResourcePath.DatabasePath)[0].DataContainers.ForEach(container => valueDropdownList.Add(new ValueDropdownItem<string>(container.Name, container.Key)));
        return valueDropdownList;
    }
}