using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class MenuInitState : IEnterState
{
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        return UniTask.CompletedTask;
    }
}
