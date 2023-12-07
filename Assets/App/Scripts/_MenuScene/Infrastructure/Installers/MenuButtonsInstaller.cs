using UnityEngine;
using Zenject;

public class MenuButtonsInstaller : MonoInstaller
{
    [SerializeField] private CustomButton _exitToStartSceneButton;
    [SerializeField] private Transform _levelButtonsTransform;
    public override void InstallBindings()
    {
        Container.Bind<StartSceneButtonLogic>().AsTransient();
        Container.Bind<LevelButtonLogic>().AsTransient();
        
        Container.Bind<IButton>().To<StartSceneButtonLogic>().WhenInjectedIntoInstance(_exitToStartSceneButton);
        BindLevelButtons();
    }

    private void BindLevelButtons()
    {   
        LevelButton[] levelButtons = _levelButtonsTransform.GetComponentsInChildren<LevelButton>();
        foreach (var levelButton in levelButtons)
            Container.Bind<IButton>().To<LevelButtonLogic>().WithArguments(levelButton).WhenInjectedIntoInstance(levelButton.Button);
    }
}