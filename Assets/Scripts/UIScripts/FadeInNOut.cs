using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFader : MonoBehaviour
{
    public Image targetImage;           // Assign this in the Inspector
    public float fadeDuration = 1f;     // Time to fade in/out

    private bool isFading = false;

    public void StartFade()
    {
        if (!isFading)
        {
            StartCoroutine(FadeInOut());
        }
    }

    private IEnumerator FadeInOut()
    {
        isFading = true;

        // Fade in
        yield return StartCoroutine(Fade(0f, 1f));

        // Optional: Pause at full opacity
        yield return new WaitForSeconds(0.2f);

        // Fade out
        yield return StartCoroutine(Fade(1f, 0f));

        isFading = false;
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;
        Color color = targetImage.color;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            targetImage.color = color;

            time += Time.deltaTime;
            yield return null;
        }

        // Ensure final alpha is set
        color.a = endAlpha;
        targetImage.color = color;
    }
}
