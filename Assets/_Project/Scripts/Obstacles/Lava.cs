using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) // Load the defeat scene if the player touches it
    {
        if(collision.collider.TryGetComponent<PlayerController>(out var player))
            SceneManager.LoadScene("Defeat Scene");
    }

}
