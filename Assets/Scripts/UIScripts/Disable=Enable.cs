using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueImageAudioSwitcher : MonoBehaviour
{
    [Header("Dialogue Objects")]
    public GameObject currentDialogue;  // The currently active dialogue object
    public GameObject nextDialogue;     // The next dialogue object to enable

    [Header("Image Switching")]
    public Image[] targetImages;        // Array of UI Images to change
    public Sprite[] newSprites;         // Array of new sprites (should match targetImages length)

    [Header("Audio Settings")]
    public AudioClip switchSound;       // The .wav sound to play after delay (optional)
    public float audioDelay = 2f;       // Time to wait before playing the audio

    [Header("Volume Control")]
    public Slider volumeSlider;  // UI Slider for volume control
    private float volume = 1.0f; // Default volume (max)

    [Header("Button Settings")]
    public Button dialogueButton;    // Button that goes to the next dialogue
    public GameObject buttonContainer;  // The parent object to enable/disable the button

    private AudioManager audioManager; // Reference to the AudioManager

    private void Start()
    {
        // Find the AudioManager in the scene (there should only be one)
        audioManager = FindObjectOfType<AudioManager>();

        if (volumeSlider != null)
        {
            volume = volumeSlider.value;  // Set initial volume from slider
            volumeSlider.onValueChanged.AddListener(SetVolume); // Update volume dynamically
        }

        // Ensure the button is hidden at the start
        if (buttonContainer != null)
        {
            buttonContainer.SetActive(false);
        }

        // Add listener to the button for advancing dialogue
        if (dialogueButton != null)
        {
            dialogueButton.onClick.AddListener(OnButtonClick);
        }
    }

    public void SwitchDialogueAndImages()
    {
        // Stop the current audio using the AudioManager
        StopCurrentAudio();

        // Disable the current dialogue and enable the next one
        if (currentDialogue != null)
        {
            currentDialogue.SetActive(false);  // Disable old dialogue text
            Debug.Log("Old dialogue hidden.");
        }

        if (nextDialogue != null)
        {
            nextDialogue.SetActive(true);  // Enable new dialogue text
            Debug.Log("New dialogue shown.");
        }

        // Change the images (sprites) for UI elements
        if (targetImages.Length == newSprites.Length)
        {
            for (int i = 0; i < targetImages.Length; i++)
            {
                if (targetImages[i] != null && newSprites[i] != null)
                {
                    targetImages[i].sprite = newSprites[i];  // Update sprite
                }
            }
        }
        else
        {
            Debug.LogError("Mismatch: Ensure targetImages and newSprites have the same length!");
        }

        // Show the dialogue button after the dialogue switch
        if (buttonContainer != null)
        {
            buttonContainer.SetActive(true);
        }

        // Play the new audio using the AudioManager
        if (switchSound != null)
        {
            audioManager.PlayAudio(switchSound, volume);
        }
    }

    private void StopCurrentAudio()
    {
        // We no longer need to stop the audio manually, it's handled by the AudioManager
    }

    private void SetVolume(float newVolume)
    {
        volume = newVolume;  // Set volume dynamically based on slider
    }

    // Function called when the button is clicked
    private void OnButtonClick()
    {
        // Hide the button after it's clicked
        if (buttonContainer != null)
        {
            buttonContainer.SetActive(false);
        }

        // Call the SwitchDialogueAndImages function after button click to continue the dialogue
        SwitchDialogueAndImages();
    }
}
