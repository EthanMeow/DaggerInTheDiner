using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightningFlash : MonoBehaviour
{
    public Image flashImage;         // The full-screen image used for the flash
    public float flashDuration = 0.1f;  // Duration of the flash
    public float fadeOutDuration = 0.5f; // Duration to fade out after the flash
    public float timerDuration = 5f;     // The time before the flash occurs

    private float timer;  // Timer to track the countdown

    private void Start()
    {
        // Initialize the timer
        timer = timerDuration;
    }

    private void Update()
    {
        // Decrease the timer each frame
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            // Trigger the flash when the timer runs out
            StartCoroutine(FlashScreen());
            timer = -1; // Prevent further flashes once triggered
        }
    }

    private IEnumerator FlashScreen()
    {
        // Ensure the image is fully transparent initially
        flashImage.color = new Color(flashImage.color.r, flashImage.color.g, flashImage.color.b, 0);  // Fully transparent (alpha = 0)

        // Fade the screen to visible (using the image's current color)
        float timeElapsed = 0f;
        while (timeElapsed < flashDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / flashDuration);  // Fade to full opacity
            flashImage.color = new Color(flashImage.color.r, flashImage.color.g, flashImage.color.b, alpha);
            yield return null;
        }

        // Immediately start fading out after the flash duration
        timeElapsed = 0f;
        while (timeElapsed < fadeOutDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, timeElapsed / fadeOutDuration);  // Fade back to transparent
            flashImage.color = new Color(flashImage.color.r, flashImage.color.g, flashImage.color.b, alpha);
            yield return null;
        }

        // Ensure the alpha is fully 0 after fading out
        flashImage.color = new Color(flashImage.color.r, flashImage.color.g, flashImage.color.b, 0);
    }
}
