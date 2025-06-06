using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeImageAfterDelay : MonoBehaviour
{
    public Image targetImage;        // The UI Image you want to change
    public Sprite newSprite;         // The new Sprite to apply
    public float delayInSeconds = 2; // Delay before changing the image

    // This function should be linked to the button's OnClick event
    public void OnButtonPressed()
    {
        StartCoroutine(ChangeImageWithDelay());
    }

    private IEnumerator ChangeImageWithDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        if (targetImage != null && newSprite != null)
        {
            targetImage.sprite = newSprite;
        }
    }
}
