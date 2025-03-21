using UnityEngine;

public class PersistentCanvas : MonoBehaviour
{
    private static PersistentCanvas instance;
    private string saveKey; // Unique key to store the active state

    private void Awake()
    {
        // Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        // Generate a unique key based on the canvas name
        saveKey = "PersistentCanvas_" + gameObject.name;

        // Ensure the canvas is enabled initially in editor
        if (!Application.isPlaying)
        {
            gameObject.SetActive(true); // Force it to be active when starting the scene in editor
        }
        else
        {
            // In play mode, restore state
            if (PlayerPrefs.HasKey(saveKey))
            {
                bool wasActive = PlayerPrefs.GetInt(saveKey) == 1;
                gameObject.SetActive(wasActive);
            }
        }
    }

    private void OnDisable()
    {
        SaveState();
    }

    private void OnDestroy()
    {
        SaveState();
    }

    private void SaveState()
    {
        if (Application.isPlaying)
        {
            PlayerPrefs.SetInt(saveKey, gameObject.activeSelf ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
