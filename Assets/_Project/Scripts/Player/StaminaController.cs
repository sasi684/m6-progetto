using UnityEngine;
using UnityEngine.Events;

public class StaminaController : MonoBehaviour
{

    [SerializeField] private float _currentStamina;
    [SerializeField] private int _maxStamina;
    [SerializeField] private UnityEvent<float, int> _onStaminaChanged; // This event call the function to update the stamina in the UI

    private void Start()
    {
        _currentStamina = _maxStamina; // Initialize stamina
        _onStaminaChanged.Invoke(_currentStamina, _maxStamina);
    }

    public float GetCurrentStamina() => _currentStamina;

    public void ConsumeStamina(float consume) // Works the same as the health
    {
        _currentStamina -= consume;

        if (_currentStamina < 0)
            _currentStamina = 0;

        _onStaminaChanged.Invoke(_currentStamina, _maxStamina); // Update the UI
    }

    public void GainStamina(float gain) // Regen the stamina
    {
        if (_currentStamina < _maxStamina)
        {
            _currentStamina += gain;
            _onStaminaChanged.Invoke(_currentStamina, _maxStamina);
        }
    }

}
