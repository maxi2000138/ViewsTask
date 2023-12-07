public class ShopButtonLogic : IButton
{
    private readonly SceneLoaderWithCurtains _sceneLoaderWithCurtains;
    private readonly ScenesConfig _scenesConfig;

    public ShopButtonLogic(SceneLoaderWithCurtains sceneLoaderWithCurtains, ScenesConfig scenesConfig)
    {
        _sceneLoaderWithCurtains = sceneLoaderWithCurtains;
        _scenesConfig = scenesConfig;
    }
    
    public void OnClick()
    {
        _sceneLoaderWithCurtains.ShowCurtainsAndLoadScene(_scenesConfig.ScenesName[SceneType.Shop]);
    }
}
