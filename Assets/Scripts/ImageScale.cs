using UnityEngine;
using UnityEngine.UI;

public class ChangeImageScaleOnButtonPress : MonoBehaviour
{
    public RectTransform targetImage;  // The UI Image's RectTransform to scale
    public Vector3 newScale = new Vector3(1.5f, 1.5f, 1f);  // The target scale (no effect on Z)
    public Button triggerButton;       // The button that triggers the scale change

    void Start()
    {
        if (triggerButton != null)
        {
            triggerButton.onClick.AddListener(ChangeScale);
        }
    }

    void ChangeScale()
    {
        if (targetImage != null)
        {
            // Set the new scale on X and Y (Z will remain unaffected for UI)
            targetImage.localScale = new Vector3(newScale.x, newScale.y, targetImage.localScale.z);
        }
    }
}
