using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{

    [SerializeField] private int _coinsCounter;
    [SerializeField] private UnityEvent<int, int> _onCoinsCounterChanged;

    private int _totalCoins; // The number of coins in each level

    private void Start() // Initialize the current coins counter
    {
        _coinsCounter = 0;
        _onCoinsCounterChanged.Invoke(_coinsCounter, _totalCoins);
    }

    public void AddCoinToTotal() // Add coin to total whenever its loaded in
    {
        _totalCoins++;
        _onCoinsCounterChanged.Invoke(_coinsCounter, _totalCoins);
    }

    public void AddCoinToCounter() // Add a coin to counter whenever one is picked up
    {
        _coinsCounter++;
        _onCoinsCounterChanged.Invoke(_coinsCounter, _totalCoins);
    }

}
