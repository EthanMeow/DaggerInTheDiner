using UnityEngine;

public class EnableAfterTime : MonoBehaviour
{
    public GameObject targetObject; // Assign in the Inspector
    public float delay = 2f;

    // This method will appear in the Button's OnClick() list
    public void EnableAfterDelay()
    {
        StartCoroutine(EnableRoutine());
    }

    private System.Collections.IEnumerator EnableRoutine()
    {
        yield return new WaitForSeconds(delay);

        if (targetObject != null)
            targetObject.SetActive(true);
    }
}
