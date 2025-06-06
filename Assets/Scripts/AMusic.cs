using UnityEngine;

public class PersistentAudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    public static PersistentAudioPlayer Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
