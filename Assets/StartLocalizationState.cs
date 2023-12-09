using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class StartLocalizationState : IEnterState
{
    private readonly LocalizationService _localizationService;
    public StartLocalizationState(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        _localizationService.FindAllTextAndLocalize();
        gameStateMachine.Enter<StartLoopState>();
        return UniTask.CompletedTask;
    }
}
