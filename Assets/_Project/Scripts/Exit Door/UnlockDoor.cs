using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{

    private bool _isOpen;
    private MeshRenderer[] _meshes;

    private void Awake()
    {
        _meshes = GetComponentsInParent<MeshRenderer>(); // Get all the meshes in the game object to update their materials later
    }

    public void OpenFinalDoor(int coins, int totalCoins) // Checks if you got all the coins in the level and eventually unlocks the door, plays a hooray sound and makes it green
    {
        if(coins >= totalCoins)
        {
            _isOpen = true;

            GetComponent<AudioSource>().Play();

            foreach(var mesh in _meshes) mesh.material.color = Color.green;
        }
    }

    private void OnCollisionEnter(Collision collision) // If the door is open, loads the next scene in index order (new level or victory scene)
    {
        if (_isOpen && collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

}
