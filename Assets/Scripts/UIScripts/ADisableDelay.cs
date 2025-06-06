using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public GameObject targetObject; // Assign in the Inspector
    public float delay = 2f;

    // This function will appear in the Unity Button OnClick list
    public void DisableAfterDelay()
    {
        StartCoroutine(DisableRoutine());
    }

    private System.Collections.IEnumerator DisableRoutine()
    {
        yield return new WaitForSeconds(delay);

        if (targetObject != null)
            targetObject.SetActive(false);
    }
}
