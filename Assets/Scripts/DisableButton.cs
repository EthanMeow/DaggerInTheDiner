using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HideAndShowButtons : MonoBehaviour
{
    public List<GameObject> buttonsToHide; // Assign the Button GameObjects here
    public float delayInSeconds = 2f;

    public void HideButtonsThenShow()
    {
        StartCoroutine(HideAndWait());
    }

    private IEnumerator HideAndWait()
    {
        // Hide (disable) all buttons
        foreach (GameObject btnObj in buttonsToHide)
        {
            if (btnObj != null)
                btnObj.SetActive(false);
        }

        yield return new WaitForSeconds(delayInSeconds);

        // Show (re-enable) all buttons
        foreach (GameObject btnObj in buttonsToHide)
        {
            if (btnObj != null)
                btnObj.SetActive(true);
        }
    }
}
