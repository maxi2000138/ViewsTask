using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;

public class ShopLoopState : IEnterState
{
    private readonly SceneLoaderWithCurtains _sceneLoaderWithCurtains;

    public ShopLoopState(SceneLoaderWithCurtains sceneLoaderWithCurtains)
    {
        _sceneLoaderWithCurtains = sceneLoaderWithCurtains;
    }
    
    public async UniTask Enter(IGameStateMachine gameStateMachine)
    {
        await _sceneLoaderWithCurtains.HideCurtains();
    }
}
