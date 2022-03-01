using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string MenuScene = "2Maps";
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject SettingsMenuUI;

    public ARSessionOrigin referenceToSessionOrigin;
    public Transform t;
    public GameObject objectsToScale;

    public LocationInfoPanel locationInfoPanel;

    #region OptionsScreen
//zet de options panel op scherm
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    //zet de options menu op de scherm
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    //deze gaat naar de main menu
    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuScene);
    }
    //eindigt de eel applicatie
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
    #region SettingsScreen
//zet de settings op de scherm
    public void LoadSettings()
    {
        SettingsMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }
    //haalt settings weg
    public void DeloadSettings()
    {
        SettingsMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }
    //functie om Volume te zetten
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    //functie om Graphic quality te zetten
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    //de scale van alle objecten te bepalen
    public void OnValueChange(float value)
    {
        referenceToSessionOrigin.MakeContentAppearAt(objectsToScale.transform, Quaternion.identity);
        objectsToScale.transform.localScale = new Vector3(value, value, value);
    }
    #endregion
    #region InfoScreen
//maakt de info uit
    public void exitLocationInfo1()
    {
       GetComponentInParent<RectTransform>().gameObject.SetActive(false);
    }
    #endregion
}
