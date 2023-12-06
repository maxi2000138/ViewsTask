using UnityEngine;
using Zenject;

public class MenuButtonsInstaller : MonoInstaller
{
    [SerializeField] private IButton _exitToStartSceneButton;
    public override void InstallBindings()
    {
        
    }
}

public interface IButton
{
    
}
