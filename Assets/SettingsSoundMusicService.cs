public class SettingsSoundMusicService
{
    private MusicPlayer _musicPlayer;
    private IDataContainer<bool> _musicDataContainer;
    private IDataContainer<bool> _soundsDataContainer;
    private readonly DataContainersIds _dataContainersIds;
    private readonly IDataContainersStorage _dataContainersStorage;
    private bool _initialized = false;


    public SettingsSoundMusicService(MusicPlayer musicPlayer, IDataContainersStorage dataContainersStorage, DataContainersIds dataContainersIds)
    {
        _musicPlayer = musicPlayer;
        _dataContainersIds = dataContainersIds;
        _dataContainersStorage = dataContainersStorage;
    }
    
    public void SetMusicState()
    {
        Initialize();
        
        if (_musicDataContainer.Data)
            _musicPlayer.UnmuteMusics();
        else 
            _musicPlayer.MuteMusics();
    }

    public void SetSoundsState()
    {
        Initialize();

        if (_soundsDataContainer.Data)
            _musicPlayer.UnmuteSounds();
        else 
            _musicPlayer.MuteSounds();
    }

    private void Initialize()
    {
        if (_initialized)
            return;
        
        _musicDataContainer = _dataContainersStorage.GetContainer<bool>(_dataContainersIds.MusicState);
        _soundsDataContainer = _dataContainersStorage.GetContainer<bool>(_dataContainersIds.SoundsState);
        _initialized = true;
    }
}