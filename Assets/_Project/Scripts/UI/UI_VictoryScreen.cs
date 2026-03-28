using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_VictoryScreen : MonoBehaviour
{

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
    }

    public void OnClickPlayAgain() // Restart from the beginning
    {
        ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToLevel);
    }

    public void OnClickMainMenu() // Go back to main menu
    {
        ScreenFader.Instance.StartFadeToOpaque(ChangeSceneToMainMenu);
    }

    private void ChangeSceneToLevel()
    {
        SceneManager.LoadScene("Level 1");
        ScreenFader.Instance.StartFadeToTransparent();
    }

    private void ChangeSceneToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        ScreenFader.Instance.StartFadeToTransparent();
    }

}
