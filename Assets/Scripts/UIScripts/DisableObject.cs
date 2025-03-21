using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject targetObject; // The object to disable

    public void DisableTarget()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
