using UnityEngine;
using TMPro;

public class UIObjectAndTextSwitcher : MonoBehaviour
{
    [Header("UI Objects")]
    public GameObject[] uiObjects; // List of all UI objects to switch between
    public GameObject selectedObject; // The object to enable

    [Header("Text Descriptions")]
    public TextMeshProUGUI[] descriptionTexts; // List of all description texts to disable
    public TextMeshProUGUI selectedText; // The text to enable for the selected object

    [Header("Menu Parent")]
    public GameObject menuParent; // The main menu object

    private void Start()
    {
        ResetMenu(); // Ensures the menu starts in a clean state
    }

    private void OnEnable()
    {
        ResetMenu(); // Reset menu when it's reopened
    }

    public void SwitchObjectAndText()
    {
        // Disable all UI objects in the list
        foreach (GameObject obj in uiObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        // Enable the selected UI object
        if (selectedObject != null)
        {
            selectedObject.SetActive(true);
        }

        // Disable all description texts in the list
        foreach (TextMeshProUGUI text in descriptionTexts)
        {
            if (text != null)
            {
                text.gameObject.SetActive(false);
            }
        }

        // Enable the selected description text
        if (selectedText != null)
        {
            selectedText.gameObject.SetActive(true);
        }
    }

    public void ResetMenu()
    {
        // Hide all UI objects and text when menu is reopened
        foreach (GameObject obj in uiObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        foreach (TextMeshProUGUI text in descriptionTexts)
        {
            if (text != null)
            {
                text.gameObject.SetActive(false);
            }
        }
    }

    public void OpenMenu()
    {
        if (menuParent != null)
        {
            menuParent.SetActive(true);
            ResetMenu(); // Ensure everything resets when opening
        }
    }

    public void CloseMenu()
    {
        if (menuParent != null)
        {
            menuParent.SetActive(false);
        }
    }
}