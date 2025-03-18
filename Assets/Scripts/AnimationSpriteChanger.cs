using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIImageEffect : MonoBehaviour
{
    public Image targetImage;        // Assign the UI Image component
    public Sprite[] frames;          // Array of sprites for animation
    public float frameRate = 0.1f;   // Time between frames
    public float startDelay = 2f;    // Delay before animation starts

    public float growthSpeed = 1f;   // How fast the image grows
    public float fadeSpeed = 1f;     // How fast the image fades
    public float moveSpeed = 1f;     // How fast the image moves

    private int currentFrame = 0;    // Tracks the current frame
    private RectTransform rectTransform;
    private Color originalColor;

    void Start()
    {
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();  // Get Image component if not assigned
        }

        rectTransform = targetImage.GetComponent<RectTransform>(); // Get RectTransform
        originalColor = targetImage.color; // Store original color

        if (frames.Length > 0)
        {
            StartCoroutine(StartEffectAfterDelay());
        }
        else
        {
            Debug.LogError("No sprites assigned for animation!");
        }
    }

    IEnumerator StartEffectAfterDelay()
    {
        yield return new WaitForSeconds(startDelay);  // Wait before starting
        StartCoroutine(PlayEffect());
    }

    IEnumerator PlayEffect()
    {
        float elapsedTime = 0f;
        Vector3 originalSize = rectTransform.localScale;
        Color color = originalColor;

        while (color.a > 0) // Runs until completely faded out
        {
            // Change sprite at a fixed rate
            if (elapsedTime >= frameRate * currentFrame && currentFrame < frames.Length)
            {
                targetImage.sprite = frames[currentFrame];
                currentFrame++;
            }

            // Move up and left
            rectTransform.anchoredPosition += new Vector2(-moveSpeed, moveSpeed) * Time.deltaTime;

            // Increase size
            rectTransform.localScale += Vector3.one * growthSpeed * Time.deltaTime;

            // Fade out
            color.a -= fadeSpeed * Time.deltaTime;
            targetImage.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure opacity is fully 0 when done
        targetImage.color = new Color(color.r, color.g, color.b, 0f);
    }
}
