using UnityEngine;

public class CoinExtraTime : MonoBehaviour
{

    [SerializeField] private int _extraTime;
    
    private Timer _timer;
    private CoinManager _coinManager;

    private ParticleSystem _pickUpParticles;

    private void Awake()
    {
        _timer = FindAnyObjectByType<Timer>();
        _coinManager = FindAnyObjectByType<CoinManager>();
        _coinManager.AddCoinToTotal(); // Add the coin to the total coins in the level

        _pickUpParticles = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player")) // If the player touches the coin, add a coin to the counter and add extra time to the timer
        {
            _timer.AddTime(_extraTime);
            _coinManager.AddCoinToCounter();

            _pickUpParticles.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            Destroy(gameObject);
        }
    }

}
