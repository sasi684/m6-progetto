using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{

    void Update() // Simple 360 degree rotation animation
    {
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * 30 * Time.deltaTime);
        transform.rotation = transform.rotation * deltaRotation;
    }
}
