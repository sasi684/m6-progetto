using UnityEngine;

public class CoinAnimation : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;

    private void Update() // Simple 360 degree rotation animation
    {
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * _rotationSpeed * Time.deltaTime);
        transform.rotation = transform.rotation * deltaRotation;
    }

}
