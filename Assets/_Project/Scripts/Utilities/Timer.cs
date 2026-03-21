using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] private int _totalLevelTime; // Time until defeat different for each level
    [SerializeField] private UnityEvent<int> _onTimeChanged;  // Event used to update the UI

    private int _currentTimeLeft; // To keep track of the time left and display it in the UI
    private float _lastTimerUpdate = 0f;

    private void Start()
    {
        _currentTimeLeft = _totalLevelTime;
        _onTimeChanged.Invoke(_currentTimeLeft);
    }

    private void Update()
    {
        if (_currentTimeLeft > 0 && Time.time - _lastTimerUpdate > 1f) // Keep updating the UI and the timer each second and load the defeat scene if it goes to zero
        {
            _currentTimeLeft -= 1;
            _lastTimerUpdate = Time.time;
            _onTimeChanged.Invoke(_currentTimeLeft);
        }
        else if (_currentTimeLeft <= 0)
            SceneManager.LoadScene("Defeat Scene");
    }

    public void AddTime(int time) // Used from coins to add extra time left
    {
        _currentTimeLeft += time;
    }

}
