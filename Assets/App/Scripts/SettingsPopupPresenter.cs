public class SettingsPopupPresenter : ISettingsPopupPresenter
{
    private SpriteToggle _musicToggle;
    private SpriteToggle _soundsToggle;
    private readonly IDataContainersStorage _dataContainersStorage;
    private readonly DataContainersIds _dataContainersIds;
    private readonly SettingsSoundMusicService _settingsSoundMusicService;
    private IDataContainer<bool> _musicStateContainer;
    private IDataContainer<bool> _soundsStateContainer;

    public SettingsPopupPresenter(IDataContainersStorage dataContainersStorage, DataContainersIds dataContainersIds, SettingsSoundMusicService settingsSoundMusicService)
    {
        _dataContainersStorage = dataContainersStorage;
        _dataContainersIds = dataContainersIds;
        _settingsSoundMusicService = settingsSoundMusicService;
    }
    
    public void Construct(SpriteToggle musicToggle, SpriteToggle soundsToggle)
    {
        _soundsToggle = soundsToggle;
        _musicToggle = musicToggle;

        _musicStateContainer = _dataContainersStorage.GetContainer<bool>(_dataContainersIds.MusicState);
        _soundsStateContainer = _dataContainersStorage.GetContainer<bool>(_dataContainersIds.SoundsState);
    }

    public void InitButtons()
    {
        _soundsToggle.SetSprite(_soundsStateContainer.Data);
        _musicToggle.SetSprite(_musicStateContainer.Data);
    }

    public void MusicButtonAction()
    {
        _musicStateContainer.Data = !_musicStateContainer.Data;
        _musicStateContainer.Save();
        _musicToggle.SetSprite(_musicStateContainer.Data);
        _settingsSoundMusicService.SetMusicState();
    }

    public void SoundsButtonAction()
    {
        _soundsStateContainer.Data = !_soundsStateContainer.Data;
        _soundsStateContainer.Save();
        _soundsToggle.SetSprite(_soundsStateContainer.Data);
        _settingsSoundMusicService.SetSoundsState();
    }
}