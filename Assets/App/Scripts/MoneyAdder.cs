using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class MoneyAdder : MonoBehaviour
{
    private IDataContainersStorage _dataContainersStorage;
    private DataContainersIds _dataContainersIds;

    [Inject]
    private void Construct(IDataContainersStorage dataContainersStorage, DataContainersIds dataContainersIds)
    {
        _dataContainersIds = dataContainersIds;
        _dataContainersStorage = dataContainersStorage;
    }
    
    [Button]
    public void AddMoney(int amount)
    {
        _dataContainersStorage.GetContainer<int>(_dataContainersIds.Money).Data += amount;
    }
}
