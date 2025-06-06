using UnityEngine;

public class DontDestroyAndForceActive : MonoBehaviour
{
    private static bool alreadyExists = false;

    private void Awake()
    {
        // Check if another instance already exists
        if (alreadyExists)
        {
            Debug.LogWarning($"Duplicate {gameObject.name} found, destroying this instance.");
            Destroy(gameObject);
            return;
        }

        // Mark as the singleton instance
        alreadyExists = true;

        // Ensure this object isn't destroyed on scene load
        DontDestroyOnLoad(gameObject);

        // Ensure it's active
        if (!gameObject.activeSelf)
        {
            Debug.LogWarning($"{gameObject.name} was inactive, reactivating.");
            gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        Debug.Log($"{gameObject.name} is active and enabled.");
    }

    private void OnDisable()
    {
        Debug.LogWarning($"{gameObject.name} was disabled! Re-enabling...");

        // Re-enable if something tries to disable it
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        if (alreadyExists)
        {
            alreadyExists = false;
            Debug.Log($"{gameObject.name} destroyed, resetting flag.");
        }
    }
}
