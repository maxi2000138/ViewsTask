using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class LevelButtonsContainer : MonoBehaviour
{
    private List<LevelButton> _levelButtons;
    private IDataContainersStorage _dataContainersStorage;
    private DataContainersIds _dataContainersIds;


    [Inject]
    private void Construct(IDataContainersStorage dataContainersStorage, DataContainersIds dataContainersIds)
    {
        _dataContainersStorage = dataContainersStorage;
        _dataContainersIds = dataContainersIds;
    }
    
    public void Initialize()
    {
        _levelButtons = GetComponentsInChildren<LevelButton>().ToList();
        _dataContainersStorage.GetContainer<int>(_dataContainersIds.LevelsAmount).Data = _levelButtons.Count;
    }

    public void UpdateButtonsState(int lastCompletedLevel)
    {
        
        foreach (var levelButton in _levelButtons)
        {
            levelButton.SetState(levelButton.LevelNumber <= lastCompletedLevel+1);
        }
    }
}