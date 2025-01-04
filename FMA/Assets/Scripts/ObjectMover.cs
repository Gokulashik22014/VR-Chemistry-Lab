using System.Collections; // Add this line
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Transform targetPosition; // The position to move to
    private Vector3 originalPosition; // The original position of the object
    private bool isMoving = false; // To track if the object is currently moving

    private void Start()
    {
        originalPosition = transform.position; // Store the original position
    }

    private void Update()
    {
        // Optionally handle input directly if needed (e.g., VR buttons)
    }

    public void MoveToTarget()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveObject(transform.position, targetPosition.position, 1f)); // Move to target over 1 second
        }
    }

    public void ReturnToOriginal()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveObject(transform.position, originalPosition, 1f)); // Return to original over 1 second
        }
    }

    private IEnumerator MoveObject(Vector3 startPos, Vector3 targetPos, float duration)
    {
        isMoving = true;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        transform.position = targetPos; // Ensure the object is at the target position
        isMoving = false; // Reset moving state
    }
}
