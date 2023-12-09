using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class ShopInitState : IEnterState
{
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        gameStateMachine.Enter<ShopLocalizationState>();
        return UniTask.CompletedTask;
    }
}