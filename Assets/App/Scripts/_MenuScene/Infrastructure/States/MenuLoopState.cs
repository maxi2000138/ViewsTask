using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class MenuLoopState : IEnterState
{
    private readonly SceneLoaderWithCurtains _sceneLoaderWithCurtains;

    public MenuLoopState(SceneLoaderWithCurtains sceneLoaderWithCurtains)
    {
        _sceneLoaderWithCurtains = sceneLoaderWithCurtains;
    }
    
    public async UniTask Enter(IGameStateMachine gameStateMachine)
    {
        await _sceneLoaderWithCurtains.HideCurtains();
    }
}
