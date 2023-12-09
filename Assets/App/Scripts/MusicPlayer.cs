using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private CustomAudioClip _backgroundMusic;
    [SerializeField] private CustomAudioClip _buttonClickSound;

    [SerializeField] private List<CustomAudioClip> _musics;
    [SerializeField] private List<CustomAudioClip> _sounds;

    public void PlayBackgroundMusic() => _backgroundMusic.Play();
    public void PLayClickSound() => _buttonClickSound.Play();
    
    public void UnmuteSounds() => UnmuteVolume(_sounds);
    public void UnmuteMusics() => UnmuteVolume(_musics);

    public void MuteSounds() => MuteVolume(_sounds);
    public void MuteMusics() => MuteVolume(_musics);

    private void MuteVolume(List<CustomAudioClip> audioClips)
    {
        foreach (CustomAudioClip music in audioClips)
            music.SetVolume(0f);
    }
    
    private void UnmuteVolume(List<CustomAudioClip> audioClips)
    {
        foreach (CustomAudioClip music in audioClips)
            music.SetVolume(music.Volume);
    }
}