using UnityEngine;
using UnityEngine.UI;

public class UIImageFader : MonoBehaviour
{
    public Image uiImage; // Assign the UI Image component in the Inspector
    public float fadeSpeed = 1f; // Speed of the fade effect
    public bool fadeInOnStart = false; // Should the image fade in or out on start?

    private float targetAlpha; // Target transparency level (0 = invisible, 1 = fully visible)
    private bool isFading = false;

    private void Start()
    {
        if (uiImage == null)
        {
            uiImage = GetComponent<Image>(); // Auto-assign if not set
        }

        if (uiImage == null)
        {
            Debug.LogError("No Image component found on " + gameObject.name);
            return;
        }

        // Set initial alpha based on start fade option
        if (fadeInOnStart)
        {
            uiImage.color = new Color(uiImage.color.r, uiImage.color.g, uiImage.color.b, 0f);
            FadeIn();
        }
        else
        {
            uiImage.color = new Color(uiImage.color.r, uiImage.color.g, uiImage.color.b, 1f);
            FadeOut();
        }
    }

    private void Update()
    {
        if (isFading)
        {
            // Gradually change the alpha value
            Color currentColor = uiImage.color;
            float newAlpha = Mathf.MoveTowards(currentColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
            uiImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            // Stop fading once the target opacity is reached
            if (Mathf.Approximately(uiImage.color.a, targetAlpha))
            {
                isFading = false;
            }
        }
    }

    // Call this to fade in (make the image fully visible)
    public void FadeIn()
    {
        targetAlpha = 1f;
        isFading = true;
    }

    // Call this to fade out (make the image invisible)
    public void FadeOut()
    {
        targetAlpha = 0f;
        isFading = true;
    }
}
