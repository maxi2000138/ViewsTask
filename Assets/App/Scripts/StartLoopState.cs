using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class StartLoopState : IEnterState
{
    private readonly SceneLoaderWithCurtains _sceneLoaderWithCurtains;

    public StartLoopState(SceneLoaderWithCurtains sceneLoaderWithCurtains)
    {
        _sceneLoaderWithCurtains = sceneLoaderWithCurtains;
    }
    
    public async UniTask Enter(IGameStateMachine gameStateMachine)
    {
        await _sceneLoaderWithCurtains.HideCurtains();
    }
}
