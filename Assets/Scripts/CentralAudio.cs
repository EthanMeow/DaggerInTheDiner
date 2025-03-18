using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;  // A single AudioSource to play all audio

    private void Awake()
    {
        // Ensure only one AudioManager exists
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);  // Destroy extra AudioManagers
        }
        else
        {
            DontDestroyOnLoad(gameObject);  // Keep AudioManager across scenes
        }

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip, float volume)
    {
        // Stop the current audio if it's playing
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Play the new audio
        audioSource.PlayOneShot(clip, volume);
    }
}
