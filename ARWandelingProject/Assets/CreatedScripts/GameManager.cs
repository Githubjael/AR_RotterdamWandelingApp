using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Test()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Location5()
    {
        SceneManager.LoadScene("location5");
    }

    public void Location4()
    {
        SceneManager.LoadScene("location4");
    }

    public void Location3()
    {
        SceneManager.LoadScene("location3");
    }

    public void Location2()
    {
        SceneManager.LoadScene("location2");
    }

    public void Location1()
    {
        SceneManager.LoadScene("location1");
    }
}
