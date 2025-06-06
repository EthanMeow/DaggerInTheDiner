using UnityEngine;

public class PersistentCanvas : MonoBehaviour
{
    private string saveKey;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        saveKey = "PersistentCanvas_" + gameObject.name;

        if (!Application.isPlaying)
        {
            gameObject.SetActive(true);
        }
        else
        {
            if (PlayerPrefs.HasKey(saveKey))
            {
                bool wasActive = PlayerPrefs.GetInt(saveKey) == 1;
                Debug.Log($"{gameObject.name} restoring active state to: {wasActive}");
                gameObject.SetActive(wasActive);
            }
            else
            {
                Debug.Log($"{gameObject.name} no saved active state found, setting active.");
                gameObject.SetActive(true);
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
