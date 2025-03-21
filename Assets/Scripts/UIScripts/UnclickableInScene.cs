using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneDisabler : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToDisableIn = "SceneName"; // Name of the scene where the button should be disabled and hidden

    private Button button;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        button = GetComponent<Button>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            // If there's no CanvasGroup, add one to control visibility
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        CheckScene(); // Check immediately on start
        SceneManager.sceneLoaded += OnSceneLoaded; // Listen for scene changes
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Remove listener when destroyed
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckScene();
    }

    private void CheckScene()
    {
        if (SceneManager.GetActiveScene().name == sceneToDisableIn)
        {
            // Disable button and hide it
            button.interactable = false;
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false; // Prevents interactions
        }
        else
        {
            // Enable button and show it
            button.interactable = true;
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true; // Allows interactions
        }
    }
}
