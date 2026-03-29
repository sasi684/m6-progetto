using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    [SerializeField] private int _currentCoins;
    [SerializeField] private event Action<int, int> _onCoinsCounterChanged;

    private int _totalCoins; // The number of coins in each level
    private UI_CoinsCounter _coinsCounter;
    private UnlockDoor _doorUnlock;

    private void Awake()
    {
        _coinsCounter = FindAnyObjectByType<UI_CoinsCounter>();
        _doorUnlock = FindAnyObjectByType<UnlockDoor>();
    }

    private void Start() // Initialize the current coins counter
    {
        _onCoinsCounterChanged += _coinsCounter.OnCoinsCounterChanged;
        _onCoinsCounterChanged += _doorUnlock.OpenFinalDoor;

        _currentCoins = 0;
        _onCoinsCounterChanged?.Invoke(_currentCoins, _totalCoins);
    }

    public void AddCoinToTotal() // Add coin to total whenever its loaded in
    {
        _totalCoins++;
        _onCoinsCounterChanged?.Invoke(_currentCoins, _totalCoins);
    }

    public void AddCoinToCounter() // Add a coin to counter whenever one is picked up
    {
        _currentCoins++;
        _onCoinsCounterChanged?.Invoke(_currentCoins, _totalCoins);
    }

}
