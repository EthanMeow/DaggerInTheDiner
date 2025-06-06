using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIImageEffect2 : MonoBehaviour
{
    public Image targetImage;        // Assign the UI Image component
    public Sprite[] frames;          // Array of sprites for animation
    public float frameRate = 0.1f;   // Time between frames
    public float startDelay = 2f;    // Delay before animation starts

    public float growthSpeed = 1f;   // How fast the image grows
    public float fadeSpeed = 1f;     // How fast the image fades
    public float moveSpeed = 1f;     // How fast the image moves

    public bool loop = false;        // Should the effect loop?

    private RectTransform rectTransform;
    private Color originalColor;
    private Vector3 originalScale;
    private Vector2 originalPosition;

    private bool isPlaying = false;

    void Start()
    {
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();  // Get Image component if not assigned
        }

        rectTransform = targetImage.GetComponent<RectTransform>(); // Get RectTransform
        originalColor = targetImage.color;
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.anchoredPosition;

        if (frames.Length > 0 && !isPlaying)
        {
            StartCoroutine(StartEffectAfterDelay());
        }
        else if (frames.Length == 0)
        {
            Debug.LogError("No sprites assigned for animation!");
        }
    }

    IEnumerator StartEffectAfterDelay()
    {
        isPlaying = true;
        yield return new WaitForSeconds(startDelay);

        do
        {
            yield return StartCoroutine(PlayEffect());
        }
        while (loop);

        isPlaying = false;
    }

    IEnumerator PlayEffect()
    {
        float elapsedTime = 0f;
        int currentFrame = 0;
        Color color = originalColor;

        rectTransform.localScale = originalScale;
        rectTransform.anchoredPosition = originalPosition;
        targetImage.color = originalColor;

        while (color.a > 0)
        {
            // Change sprite frame
            if (elapsedTime >= frameRate)
            {
                targetImage.sprite = frames[currentFrame % frames.Length];
                currentFrame++;
                elapsedTime = 0f;
            }

            // Movement, scale, fade
            rectTransform.anchoredPosition += new Vector2(-moveSpeed, moveSpeed) * Time.deltaTime;
            rectTransform.localScale += Vector3.one * growthSpeed * Time.deltaTime;
            color.a -= fadeSpeed * Time.deltaTime;
            targetImage.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure fully transparent
        targetImage.color = new Color(color.r, color.g, color.b, 0f);
    }
}
