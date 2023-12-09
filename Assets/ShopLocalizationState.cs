using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class ShopLocalizationState : IEnterState
{
    private readonly LocalizationService _localizationService;
    public ShopLocalizationState(LocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        _localizationService.FindAllTextAndLocalize();
        gameStateMachine.Enter<ShopLoopState>();
        return UniTask.CompletedTask;
    }
}