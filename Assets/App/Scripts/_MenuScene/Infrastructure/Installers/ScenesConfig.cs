using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/ScenesConfig")]
public class ScenesConfig : SerializedScriptableObject
{
    [OdinSerialize] public Dictionary<SceneType, string> ScenesName;
}

public enum SceneType
{
    Start,
    Menu,
    Shop,
}
