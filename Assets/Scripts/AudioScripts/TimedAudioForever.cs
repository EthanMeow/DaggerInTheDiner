using UnityEngine;
using System.Collections;  // Required for IEnumerator

public class BackgroundAudioPlayer : MonoBehaviour
{
    public AudioClip audioClip;  // The .wav audio clip to play
    public float delay = 0f;     // Time delay before audio starts playing
    private float volume = 0.5f; // Default volume (max)

    private AudioSource audioSource;  // AudioSource to play the audio

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;  // Set to loop (remove this line if you don't want looping)
        audioSource.volume = volume;  // Set initial volume

        // Start the delayed audio playback
        StartCoroutine(PlayAudioAfterDelay());
    }

    private IEnumerator PlayAudioAfterDelay()
    {
        yield return new WaitForSeconds(delay);  // Wait for the delay

        // Play the audio once the delay is over
        audioSource.Play();
        Debug.Log("Background audio started.");
    }

    // Method to adjust the volume dynamically
    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        audioSource.volume = volume;
    }
}
