using UnityEngine;

public abstract class LevelButtonBase: MonoBehaviour
{
    public abstract void Initialize(int levelNumber);
    public abstract void SetLVLName();
}
