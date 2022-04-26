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
    [Header("Put PauseMenu Here")]
    [Tooltip("Canvas->ForThePauseMenuScript->PauseMenu" +
        "Ga naar Canvas, ga naar de 'ForThePauseMenuScript' en dan pak je de 'Pausemenu' gameobject en plak hem hier!")]
    public GameObject PauseMenuUI;
    [Header("Put SettingsMenu Here")]
    [Tooltip("Canvas->ForThePauseMenuScript->settingsMenu" +
        "Ga naar Canvas, ga naar de 'ForThePauseMenuScript' en dan pak je de 'Settingsmenu' gameobject en plak hem hier!")]
    public GameObject SettingsMenuUI;
    [Header("Put ListOfTexts Here")]
    [Tooltip("Canvas->ListofTexts" +
        "Ga naar Canvas en dan pak je de 'ListOfTexts' gameobject en plak hem hier!")]
    public Transform listOfObjects;
    [Header("Deze werkt Automatisch")]
    [Tooltip("Doe niets met deze.")]
    public List<Transform> UIToExit;

    private void OnEnable()
    {
        foreach (Transform child in listOfObjects)
        {
            UIToExit.Add(child);
        }
    }
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
        for(int i = 0; i < UIToExit.Count; i++)
        {
            UIToExit[i].gameObject.SetActive(false);
        }
    }
}