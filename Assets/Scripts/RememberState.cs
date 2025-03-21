using UnityEngine;
using UnityEngine.UI;

public class PersistentButtonState : MonoBehaviour
{
    public string buttonID = "ThirdButtonState"; // Unique key to store state
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        // Load saved state (1 = enabled, 0 = disabled)
        if (PlayerPrefs.HasKey(buttonID))
        {
            bool isEnabled = PlayerPrefs.GetInt(buttonID) == 1;
            button.gameObject.SetActive(isEnabled);
        }
    }

    public void EnableButton()
    {
        button.gameObject.SetActive(true);
        PlayerPrefs.SetInt(buttonID, 1); // Save state as enabled
        PlayerPrefs.Save();
    }
}
