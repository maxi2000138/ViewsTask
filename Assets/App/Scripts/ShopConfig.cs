using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ShopConfig : SerializedScriptableObject
{
    
    
    private class ShopPack
    {
        public GameObject ShopItem;
        public string ShopHeaderText;
    }
    
    private class ShopItem
    {
        public int cost;
    }
}
