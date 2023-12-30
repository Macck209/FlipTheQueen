using System;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    private AudioSource audioSource;

    private float soundVolume;
    private string gameResolution;
    private bool fullScreen;
    public Slider volumeSlider;

    private void Awake()
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume", 0.7f);
        // TODO after changing scene - find new audiosource
    }
    public void LoadSettings()
    {
        soundVolume = PlayerPrefs.GetFloat("soundVolume", 0.7f);
        gameResolution = PlayerPrefs.GetString("gameResolution", "FullHD");
        fullScreen = PlayerPrefs.GetInt("fullscreen", 1) == 1 ? true : false;

        Screen.fullScreen = fullScreen;
        audioSource.volume = soundVolume;
        
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
        PlayerPrefs.SetString("gameResolution", gameResolution);
        PlayerPrefs.SetInt("fullscreen", fullScreen == true ? 1 : 0); 
        PlayerPrefs.Save();
    }

    public void ChangeSoundVolume(Single s)
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();
        soundVolume = s;
        audioSource.volume = soundVolume;
    }
    public void ChangeGameResolution(Int32 i) 
    {
        switch (i)
        {
            case 0:
                gameResolution = "WXGA";
                break;
            case 1:
                gameResolution = "FullHD";
                break;
            case 2:
                gameResolution = "QHD";
                break;
            case 3:
                gameResolution = "4K";
                break;
        }
        // TODO Resolution functionality
    }
    public void SwitchFullscreen(bool b) 
    {
        fullScreen = b;
        Screen.fullScreen= fullScreen;
        // TODO fullscreen shortcut
    }
}
