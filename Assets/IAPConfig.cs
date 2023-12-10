using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/IAPConfig")]
public class IAPConfig : ScriptableObject
{
    public List<ConsumableItem> _consumableItems;
    public List<NonConsumableItem> _nonConsumableItems;
    public List<SubscriptionItem> _subscriptionItems;
    
    
    public class ConsumableItem
    {
        public BaseIAPItem BaseData;
    }
    
    public class NonConsumableItem
    {
        public BaseIAPItem BaseData;
    }
    
    public class SubscriptionItem
    {
        public BaseIAPItem BaseData;
    }

    
    [Serializable]
    public class BaseIAPItem
    {
        public string Name;
        public string Id;
        public string Price;
    }
}