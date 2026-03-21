using UnityEngine;
using UnityEngine.Events;

public class SimpleBullet : MonoBehaviour
{

    [SerializeField] private int _damage;
    [SerializeField] private float _bulletDuration;
    [SerializeField] private float _bulletSpeed;

    private Vector3 _direction;

    private void Start()
    {
        Destroy(gameObject, _bulletDuration); // Destroy the bullet after x seconds it spawned
    }

    private void Update() // Update its position to each frame using a given direction
    {
        transform.position = transform.position + _direction * (_bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) // Deal damage, play the hurt sound and destroy the bullet when the player collides with it
    {
        if(collision.collider.TryGetComponent<LifeController>(out var life))
        {
            life.TakeDamage(_damage);

            PlayerSFX sfx = collision.gameObject.GetComponent<PlayerSFX>();
            sfx.PlayHurtSound();

            Destroy(gameObject);
        }
    }

    public void SetupBullet(Vector3 direction) => _direction = direction; // Setup the bullet with a direction

}
