using UnityEngine;
using System.Collections;

public class MoveUIObject : MonoBehaviour
{
    public Vector2 targetPosition;  // Set in Inspector
    public float moveSpeed = 500f;  // Speed (higher for UI)

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Start smooth movement
        MoveToPositionSmoothly();
    }

    public void MoveToPosition()
    {
        Debug.Log("Moving Instantly to: " + targetPosition);
        rectTransform.anchoredPosition = targetPosition;
    }

    public void MoveToPositionSmoothly()
    {
        Debug.Log("Starting Smooth Move to: " + targetPosition);
        StopAllCoroutines();
        StartCoroutine(MoveSmoothly());
    }

    private IEnumerator MoveSmoothly()
    {
        while (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) > 0.01f)
        {
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
        Debug.Log("Reached Target: " + targetPosition);
    }
}
