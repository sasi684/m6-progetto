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
        SceneManager.LoadScene("Level 1");
    }

    public void OnClickMainMenu() // Go back to main menu
    {
        SceneManager.LoadScene("Main Menu");
    }

}
