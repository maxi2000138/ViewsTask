using UnityEngine; 

public class DefaultButtonLogic : IButton
{
    public void OnClick()
    {
        Debug.Log("Default click!");        
    }
}
