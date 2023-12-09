using UnityEngine;

public class CustomAudioClip : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [field:SerializeField] public float Volume;

    public void Play() => _audioSource.Play();
    public void Stop() => _audioSource.Stop();
    public float SetVolume(float volume) => _audioSource.volume = volume;
}
