using UnityEngine;

public class CoinSimple : MonoBehaviour
{

    private CoinManager _coinManager;

    private void Awake()
    {
        _coinManager = FindAnyObjectByType<CoinManager>();
        _coinManager.AddCoinToTotal(); // Add the coin to the total coins in the level
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent<PlayerController>(out var player)) // If the player touches the coin, add a coin to the counter
        {
            _coinManager.AddCoinToCounter();
            Destroy(gameObject);
        }
    }

}
