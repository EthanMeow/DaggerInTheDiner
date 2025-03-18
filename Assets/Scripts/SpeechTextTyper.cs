using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;  // Assign your UI TextMeshPro element
    [TextArea(3, 10)]
    public string fullText;              // The text to display
    public float typingSpeed = 0.05f;    // Time between each letter
    public float startDelay = 2f;        // Delay before typing starts

    private void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>(); // Get TextMeshPro component if not assigned
        }

        textMeshPro.text = "";  // Clear the text at the start
        StartCoroutine(StartTypewriterEffect());
    }

    IEnumerator StartTypewriterEffect()
    {
        yield return new WaitForSeconds(startDelay);  // Wait before starting the effect

        foreach (char letter in fullText.ToCharArray())
        {
            textMeshPro.text += letter;  // Add one letter at a time
            yield return new WaitForSeconds(typingSpeed);  // Wait before adding next letter
        }
    }
}
