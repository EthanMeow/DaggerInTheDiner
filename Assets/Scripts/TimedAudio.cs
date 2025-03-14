using UnityEngine;

public class DelayedAudioPlayer : MonoBehaviour
{
    public AudioClip audioClip;  // Assign the .wav file here in the Inspector
    public float delay = 3f;     // Set delay time in seconds
    public float volume = 1f;    // Set the audio volume (range 0 to 1)
    public bool loop = false;    // Whether to loop the audio

    private void Start()
    {
        if (audioClip == null)
        {
            Debug.LogError("No AudioClip assigned!");
            return;
        }

        // Start delayed playback
        Invoke("PlayAudio", delay);
    }

    private void PlayAudio()
    {
        Debug.Log("Playing audio after " + delay + " seconds.");

        // Create an AudioSource dynamically
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        // Set the volume
        audioSource.volume = volume;

        // Set loop option
        audioSource.loop = loop;

        // Play the audio clip through this new AudioSource
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
