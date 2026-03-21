using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;

    public void OnClickStartGame() // Load the first level
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnClickOptions() // Open the options panel
    {
        _optionsPanel.SetActive(!_optionsPanel.activeSelf);
    }

    public void OnClickExitGame() // Close the game (only works in build)
    {
        Debug.Log("Sei uscito dal gioco");
        Application.Quit();
    }

}
