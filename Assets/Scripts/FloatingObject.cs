using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [Header("Floating Settings")]
    public float floatSpeed = 1f;  // Speed of the floating motion
    public float floatHeight = 0.5f;  // Maximum height difference

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;  // Store the initial position
    }

    void Update()
    {
        // Create a floating effect using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
