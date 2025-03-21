using UnityEngine;

[ExecuteAlways]  // This will make the script run in both play and edit mode
public class ForceCanvasOnStart : MonoBehaviour
{
    public GameObject canvasObject;  // Assign your Canvas GameObject here

    private void Awake()
    {
        // Ensure the Canvas is enabled even before the scene starts
        EnsureCanvasEnabled();
    }

    private void Start()
    {
        // Force-enable the Canvas at the start of Play mode
        EnsureCanvasEnabled();
    }

    private void EnsureCanvasEnabled()
    {
        if (canvasObject != null)
        {
            if (!canvasObject.activeSelf)
            {
                Debug.Log("Forcing Canvas to be enabled");
                canvasObject.SetActive(true);  // Force the Canvas to be enabled
            }
        }
        else
        {
            Debug.LogError("Canvas object is not assigned.");
        }
    }
}
