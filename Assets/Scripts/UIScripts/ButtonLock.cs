using UnityEngine;
using UnityEngine.UI;

public class ButtonLocker : MonoBehaviour
{
    [Header("Buttons")]
    public Button buttonToLock;   // The button that will be locked
    public Button buttonToUnlock; // The button that will unlock the other button

    private void Start()
    {
        // Initially, make sure the button is clickable
        buttonToLock.interactable = true;

        // Add listeners to the buttons
        buttonToUnlock.onClick.AddListener(LockButton);  // Lock the button
        buttonToUnlock.onClick.AddListener(UnlockButton); // Unlock the button
    }

    // Function to lock the button (disable interaction)
    public void LockButton()
    {
        buttonToLock.interactable = false; // Disable the button
    }

    // Function to unlock the button (enable interaction)
    public void UnlockButton()
    {
        buttonToLock.interactable = true; // Enable the button
    }
}
