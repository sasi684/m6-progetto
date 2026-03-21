using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{

    [SerializeField] private int _currentHP;
    [SerializeField] private int _maxHP;
    [SerializeField] private UnityEvent<int, int> _onHealthchanged; // This event call the function to update the health in the UI

    private void Start()
    {
        _currentHP = _maxHP; // Initialize the health
        _onHealthchanged.Invoke(_currentHP, _maxHP);
    }

    public void TakeDamage(int damage) // Subtract the amount passed as parameter and load the defeat scene if below or equal to zero
    {
        _currentHP -= damage;

        if (_currentHP <= 0)
        {
            SceneManager.LoadScene("Defeat Scene");
        }

        _onHealthchanged.Invoke(_currentHP, _maxHP); // Update the UI
    }

}
