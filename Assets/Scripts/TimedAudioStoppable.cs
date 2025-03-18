using UnityEngine;
using System.Collections;  // For IEnumerator

public class DelayedAudioPlayer : MonoBehaviour
{
    public AudioClip audioClip;  // Audio to be played
    public float delay = 3f;     // Time delay before the audio plays

    private AudioSource audioSource;  // AudioSource to play the audio
    private bool isAudioPlaying = false;  // Flag to check if the audio is already playing

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void Update()
    {
        // Ensure that audio doesn't start playing if it's already playing
        if (!isAudioPlaying)
        {
            StartCoroutine(PlayAudioAfterDelay());
        }
    }

    private IEnumerator PlayAudioAfterDelay()
    {
        yield return new WaitForSeconds(delay);  // Wait for the delay

        // Ensure audio doesn't play again if it's already playing
        if (!isAudioPlaying)
        {
            audioSource.Play();  // Play the audio
            isAudioPlaying = true;  // Mark audio as playing
        }
    }

    // Method to stop the audio
    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();  // Stop the audio if it's playing
            isAudioPlaying = false;  // Update the state to allow for new audio
        }
    }
}
