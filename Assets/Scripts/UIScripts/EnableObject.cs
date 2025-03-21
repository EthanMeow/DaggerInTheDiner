using UnityEngine;

public class EnableObject : MonoBehaviour
{
    public GameObject targetObject; // The object to enable

    public void EnableTarget()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}
