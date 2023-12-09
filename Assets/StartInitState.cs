using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class StartInitState : IEnterState
{
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        gameStateMachine.Enter<StartLocalizationState>();
        return UniTask.CompletedTask;
    }
}
