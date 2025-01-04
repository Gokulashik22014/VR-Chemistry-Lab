using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class ReturnToOriginalPosition : MonoBehaviour
{
    [SerializeField]private Vector3 originalPosition;
    [SerializeField] private Quaternion originalRotation;
    [SerializeField] private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Store the original position and rotation of the object
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            // Subscribe to the OnSelectExited event
            grabInteractable.onSelectExited.AddListener(OnReleased);
        }
        else
        {
            Debug.LogWarning("XRGrabInteractable component not found on this GameObject.");
        }
    }

    void OnReleased(XRBaseInteractor interactor)
    {
        // Move the object back to its original position and rotation
        StartCoroutine(MoveBackToOriginalPosition());
    }

    private IEnumerator MoveBackToOriginalPosition()
    {
        // Smoothly move the object back to its original position
        float timeElapsed = 0f;
        float duration = 1f; // Adjust the duration as needed

        Vector3 startingPosition = transform.position;
        Quaternion startingRotation = transform.rotation;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            transform.position = Vector3.Lerp(startingPosition, originalPosition, t);
            transform.rotation = Quaternion.Slerp(startingRotation, originalRotation, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the object reaches the original position and rotation
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}

