using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    private GameObject mainOptionsView, settingsView, creditsView, settingsControl;
    private AudioSource audioSource;
    private GameSettings gameSettings;



    private void Start()
    {
        gameSettings = settingsControl.GetComponent<GameSettings>(); 
        gameSettings.LoadSettings();

        mainOptionsView.SetActive(true);
        settingsView.SetActive(false);
        creditsView.SetActive(false);

        audioSource = GameObject.FindObjectOfType<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("soundVolume", 0.7f);
    }

    public void GotoSettings()
    {
        mainOptionsView.SetActive(false);
        creditsView.SetActive(false);
        settingsView.SetActive(true);

        audioSource = GameObject.FindObjectOfType<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("soundVolume", 0.7f);
    }


    public void GotoCredits()
    {
        mainOptionsView.SetActive(false);
        settingsView.SetActive(false);
        creditsView.SetActive(true);

        audioSource = GameObject.FindObjectOfType<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("soundVolume", 0.7f);
    }

    public void RevertSettings()
    {
        // TODO revert btn functionality
    }
    public void SaveSettings()
    {
        gameSettings.SaveSettings();

        settingsView.SetActive(false);
        creditsView.SetActive(false);
        mainOptionsView.SetActive(true);
        

        audioSource = GameObject.FindObjectOfType<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("soundVolume", 0.7f);
    }


    public void BackToMainMenu()
    {
        creditsView.SetActive(false);
        settingsView.SetActive(false);
        mainOptionsView.SetActive(true);
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        // TODO Show level selector instead of loading GameScene
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
