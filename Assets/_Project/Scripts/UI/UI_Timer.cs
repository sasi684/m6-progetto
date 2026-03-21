using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _timer;

    public void UpdateTimer(int timeLeft) // Update the timer in the UI
    {
        _timer.SetText(timeLeft.ToString());
    }
}
