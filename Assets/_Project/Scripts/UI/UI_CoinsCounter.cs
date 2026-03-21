using TMPro;
using UnityEngine;

public class UI_CoinsCounter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _coinsCounterText;

    public void OnCoinsCounterChanged(int coins, int maxCoins) // Update the coins count and the total coins in the current level
    {
        _coinsCounterText.text = $"{coins}/{maxCoins}";
    }

}
