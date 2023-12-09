using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class MenuLocalizationState : IEnterState
{
    private readonly LocalizationService _localizationService;
    public MenuLocalizationState(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        _localizationService.FindAllTextAndLocalize();
        gameStateMachine.Enter<MenuLoopState>();
        return UniTask.CompletedTask;
    }
}
