using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioClip _hurtSound;
    [SerializeField] private AudioSource _audio;

    public void PlayHurtSound() // Plays the hurt clip whenever the player gets hit by bullets using an Unity Event
    {
        _audio.clip = _hurtSound;
        _audio.Play();
    }

}
