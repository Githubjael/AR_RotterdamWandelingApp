using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

public class PauseMenu : MonoBehaviour
{
    ResponsiveReticle responsiveReticle;
    public AudioMixer audioMixer;
    public string MenuScene = "2Maps";
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject SettingsMenuUI;
    public GameObject[] UIToExit;
    
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
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void Exit()
    {
        for(int i = 0; i < UIToExit.Length; i++)
        {
            UIToExit[i].SetActive(false);
        }
    }
}