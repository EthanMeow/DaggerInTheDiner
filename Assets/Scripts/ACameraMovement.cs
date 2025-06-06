using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIPanZoomEffect : MonoBehaviour
{
    public RectTransform sceneWrapper;      // The parent of all UI elements to pan/zoom
    public List<RectTransform> focusPoints; // UI points to pan to
    public RectTransform bodyTarget;        // Final focus point

    public RectTransform backgroundImage;   // Your background RectTransform to reset scale
    public Vector3 backgroundOriginalScale = Vector3.one;  // The original scale to reset to

    public float moveSpeed = 2f;
    public float waitBetweenMoves = 0.5f;
    public float delayBeforeStart = 1f;
    public float resetDelay = 2f;

    public float originalZoom = 1f;          // Initial zoom scale of sceneWrapper
    public float finalZoom = 1.5f;           // Zoom in scale

    [Header("Shake Settings")]
    public float shakeMagnitude = 10f;       // How strong the shake is during movement

    private Vector3 originalPos;
    private Vector3 originalScale;

    public void StartEffect()
    {
        StartCoroutine(PlaySequenceWithDelay());
    }

    private IEnumerator PlaySequenceWithDelay()
    {
        originalPos = sceneWrapper.localPosition;
        originalScale = sceneWrapper.localScale;

        if (backgroundImage != null)
            backgroundOriginalScale = backgroundImage.localScale;

        yield return new WaitForSeconds(delayBeforeStart);
        yield return StartCoroutine(PlaySequence());

        yield return new WaitForSeconds(resetDelay);

        // Reset sceneWrapper position and scale to original values
        sceneWrapper.localPosition = originalPos;
        sceneWrapper.localScale = originalScale;

        if (backgroundImage != null)
            backgroundImage.localScale = backgroundOriginalScale;
    }

    private IEnumerator PlaySequence()
    {
        foreach (var point in focusPoints)
        {
            yield return StartCoroutine(MoveAndZoomTo(point.anchoredPosition, originalZoom));
            yield return new WaitForSeconds(waitBetweenMoves);
        }

        yield return StartCoroutine(MoveAndZoomTo(bodyTarget.anchoredPosition, finalZoom));
        yield return new WaitForSeconds(waitBetweenMoves);
    }

    private IEnumerator MoveAndZoomTo(Vector2 targetPos, float targetZoom)
    {
        Vector3 startPos = sceneWrapper.localPosition;
        float startZoom = sceneWrapper.localScale.x;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            float progress = Mathf.Clamp01(t);

            // Interpolate position and zoom
            Vector3 basePos = Vector3.Lerp(startPos, -(Vector3)targetPos, progress);
            float scale = Mathf.Lerp(startZoom, targetZoom, progress);

            // Add shake that fades out as we approach the target
            float offsetX = Random.Range(-1f, 1f) * shakeMagnitude * (1f - progress);
            float offsetY = Random.Range(-1f, 1f) * shakeMagnitude * (1f - progress);
            Vector3 shakeOffset = new Vector3(offsetX, offsetY, 0f);

            sceneWrapper.localPosition = basePos + shakeOffset;
            sceneWrapper.localScale = new Vector3(scale, scale, 1f);

            yield return null;
        }

        // Ensure exact final position and scale
        sceneWrapper.localPosition = -(Vector3)targetPos;
        sceneWrapper.localScale = new Vector3(targetZoom, targetZoom, 1f);
    }
}
