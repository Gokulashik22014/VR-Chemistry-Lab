using UnityEngine;

public class Mover : MonoBehaviour
{
    // Speed of movement
    public float speed = 2.0f;

    // Target Transform (to be assigned in the Inspector)
    [SerializeField] private Transform targetTransform;

    // Function to move to the target position
    public void MoveToTarget()
    {
        if (targetTransform != null)
        {
            StartCoroutine(MoveCoroutine(targetTransform));
        }
        else
        {
            Debug.LogWarning("Target Transform is not assigned!");
        }
    }

    private System.Collections.IEnumerator MoveCoroutine(Transform target)
    {
        // Move until we reach the target position
        while (Vector3.Distance(transform.position, target.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            yield return null; // Wait for the next frame
        }

        // Optionally snap to the target position to ensure accuracy
        transform.position = target.position;
    }
}
