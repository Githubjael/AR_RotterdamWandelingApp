using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string MenuScene = "2Maps";
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject SettingsMenuUI;

    // Update is called once per frame
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadSettings()
    {
        SettingsMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }
    public void DeloadSettings()
    {
        SettingsMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
