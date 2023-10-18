using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    private GameObject mainOptionsView, settingsView, settingsControl;

    private GameSettings gameSettings;

    private void Start()
    {
        gameSettings= settingsControl.GetComponent<GameSettings>(); 
        gameSettings.LoadSettings();

        mainOptionsView.SetActive(true);
        settingsView.SetActive(false);
    }

    public void GotoSettings()
    {
        mainOptionsView.SetActive(false);
        settingsView.SetActive(true);
    }
    public void RevertSettings()
    {
        // TODO revert btn functionality
    }
    public void SaveSettings()
    {
        gameSettings.SaveSettings();

        mainOptionsView.SetActive(true);
        settingsView.SetActive(false);
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
