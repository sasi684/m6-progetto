using UnityEngine;

public class SimpleTurret : MonoBehaviour
{

    [SerializeField] private float _range;
    [SerializeField] private LayerMask _layerMask; // Check only the player layer
    [SerializeField] private SimpleBullet _bullet;
    [SerializeField] private float _fireRate;

    private float _lastShot;

    private void Update()
    {
        if(Physics.Raycast(transform.position, transform.up, out RaycastHit hit, _range, _layerMask) && Time.time - _lastShot > _fireRate) // Check if player is in range forward
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        SimpleBullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity, transform);
        bullet.SetupBullet(transform.up);
        _lastShot = Time.time;
    }
}

/*
 * NOTE: Had to use transform.up to avoid remaking the model (sorry) 
 */
