using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class UI_Options : MonoBehaviour
{

    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private UnityEvent<float> _onSensitivityChange; // Event used to update the sensitivity in the PlayerPrefs class

    public void OnClickSaveOptions() // Save all changes made in the options menu (fake)
    {
        Debug.Log("Le opzioni sono state salvate!");
    }

    public void OnClickReturn() // Close the options panel
    {
        _optionsPanel.SetActive(false);
    }

    public void OnSlideMouseSensitivity(float sensitivity) // Change the sensitivity in the PlayerPrefs class
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        _onSensitivityChange.Invoke(sensitivity);
    }

    public void OnSlideSFXVolume(float value) // Update the volume for SFX
    {
        if(value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _audioMixer.SetFloat("SFX", volume);
        }
        else
        {
            _audioMixer.SetFloat("SFX", -80f);
        }
    }

    public void OnSlideMusicVolume(float value) // Update the volume for Music
    {
        if (value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _audioMixer.SetFloat("Music", volume);
        }
        else
        {
            _audioMixer.SetFloat("Music", -80f);
        }
    }

    public void OnSlideMasterVolume(float value) // Update the volume for Master
    {
        if(value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _audioMixer.SetFloat("Master", volume);
        }
        else
        {
            _audioMixer.SetFloat("Master", -80f);
        }
    }

}
