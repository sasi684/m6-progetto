using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private UnityEvent<float> _onSensitivityChange; // Event used to update the sensitivity in the PlayerPrefs class

    private float _mouseSens;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pauseMenuPanel.activeSelf && !ScreenFader.Instance.IsFading)
        {
            _mouseSens = PlayerPrefs.GetFloat("MouseSensitivity"); // Store the current value for the sensitivity

            _pauseMenuPanel.SetActive(true); // Show the pause menu and stop the in-game time
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None; // Unlock and show the cursor
            Cursor.visible = true;

            PlayerPrefs.SetFloat("MouseSensitivity", 0f); // Set the sensitivity to 0 so the camera doesn't move while in pause
            _onSensitivityChange.Invoke(0f);
        }
    }

    public void OnClickResumeGame() // Hide the pause menu, hide and lock the cursor and reset the mouse sensitivity to the previous value
    {
        _pauseMenuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        UnlockGame();
    }

    public void OnClickOptions() // Show the options panel
    {
        _optionsPanel.SetActive(true);
    }

    public void OnClickMainMenu() // Load the main menu scene
    {
        UnlockGame();
        ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToMainMenu);
    }

    private void ChangeSceneToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        ScreenFader.Instance.StartFadeToTransparent();
    }

    private void UnlockGame()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetFloat("MouseSensitivity", _mouseSens);
        _onSensitivityChange.Invoke(_mouseSens);
    }
}
