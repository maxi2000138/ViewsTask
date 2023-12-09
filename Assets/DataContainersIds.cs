using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class DataContainersIds : MonoBehaviour
{
    public string SoundsState => _soundsState;
    public string MusicState => _musicState;
        
    [ValueDropdown(nameof(DataContainersIDs))] 
    [SerializeField] private string _soundsState;
    
    [ValueDropdown(nameof(DataContainersIDs))] 
    [SerializeField] private string _musicState;


    private ValueDropdownList<string> DataContainersIDs()
    {
        var valueDropdownList = new ValueDropdownList<string>();
        Resources.LoadAll<DataDB>(DatabaseResourcePath.DatabasePath)[0].DataContainers.ForEach(container => valueDropdownList.Add(new ValueDropdownItem<string>(container.Name, container.Key)));
        return valueDropdownList;
    }
}