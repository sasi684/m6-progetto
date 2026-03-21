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
        SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousScene"));
    }

    public void OnClickMainMenu() // Go back to main menu
    {
        SceneManager.LoadScene("Main Menu");
    }

}
