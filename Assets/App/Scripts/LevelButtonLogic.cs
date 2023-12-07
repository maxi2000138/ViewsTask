using UnityEngine;

public class LevelButtonLogic : IButton
{
    private readonly LevelButton _levelButton;

    public LevelButtonLogic(LevelButton levelButton)
    {
        _levelButton = levelButton;
    }
    
    public void OnClick()
    {
        Debug.Log($"CLicked {_levelButton.LevelNumber}");
    }
}
