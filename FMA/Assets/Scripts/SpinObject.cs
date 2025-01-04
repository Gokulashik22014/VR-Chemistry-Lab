using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float spinSpeed = 100f; // Speed of rotation

    void Update()
    {
        // Rotate the object around the X-axis
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}
