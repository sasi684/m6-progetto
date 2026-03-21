using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{

    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _healthText;

    public void UpdateHealthBar(int currentHP, int maxHP) // Update the health bar and text using an Unity Event
    {
        _healthBar.fillAmount = (float)currentHP / maxHP;
        _healthText.text = $"HEALTH {currentHP}/{maxHP}";
    }

}
