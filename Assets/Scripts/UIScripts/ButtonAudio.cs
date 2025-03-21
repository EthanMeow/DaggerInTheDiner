using UnityEngine;
using UnityEngine.UI;

public class PlayAudioOnButtonPress : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip audioClip;  // Assign the audio clip in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Create an AudioSource component if one doesn't exist
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning("No audio clip assigned!");
        }
    }
}
