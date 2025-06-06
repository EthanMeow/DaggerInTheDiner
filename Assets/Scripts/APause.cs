using UnityEngine;

public class AudioPauseController : MonoBehaviour
{
    private AudioSource musicSource;

    void Start()
    {
        musicSource = PersistentAudioPlayer.Instance?.audioSource;
    }

    public void ToggleMusic()
    {
        if (musicSource == null) return;

        if (musicSource.isPlaying)
            musicSource.Pause();
        else
            musicSource.UnPause();
    }
}
