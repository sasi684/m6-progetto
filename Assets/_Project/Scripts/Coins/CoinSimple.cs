using UnityEngine;

public class CoinSimple : MonoBehaviour
{
    private ParticleSystem _pickUpParticles;
    private CoinManager _coinManager;

    private void Awake()
    {
        _coinManager = FindAnyObjectByType<CoinManager>();
        _coinManager.AddCoinToTotal(); // Add the coin to the total coins in the level

        _pickUpParticles = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player")) // If the player touches the coin, add a coin to the counter
        {
            _coinManager.AddCoinToCounter();

            _pickUpParticles.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;

            Destroy(gameObject,1f);
        }
    }

}
