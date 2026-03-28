using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_DefeatScreen : MonoBehaviour
{

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock and show cursor
        Cursor.visible = true;
    }

    public void OnClickPlayAgain() // Load the level where you last lost
    {
        ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToPrevious);
    }

    public void OnClickMainMenu() // Go back to main menu
    {
        ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToMainMenu);
    }

    private void ChangeSceneToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        ScreenFader.Instance.StartFadeToTransparent();
    }

    private void ChangeSceneToPrevious()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousScene"));
        ScreenFader.Instance.StartFadeToTransparent();
    }

}
