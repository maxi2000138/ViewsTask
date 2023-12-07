public class StartSceneButtonLogic : IButton
{
    private readonly SceneLoaderWithCurtains _sceneLoaderWithCurtains;
    private readonly ScenesConfig _scenesConfig;

    public StartSceneButtonLogic(SceneLoaderWithCurtains sceneLoaderWithCurtains, ScenesConfig scenesConfig)
    {
        _sceneLoaderWithCurtains = sceneLoaderWithCurtains;
        _scenesConfig = scenesConfig;
    }


    public void OnClick()
    {
        _sceneLoaderWithCurtains.ShowCurtainsAndLoadScene(_scenesConfig.ScenesName[SceneType.Start]);
    }
}
