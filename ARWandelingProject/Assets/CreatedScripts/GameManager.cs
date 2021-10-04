using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
    private void Start()
    {
    Location1();
    Location2();
    Location3();
    Location4();
    Location5();
    Exit();       
    }
    */
    private void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Location5()
    {
        SceneManager.LoadScene("location5");
    }

    private void Location4()
    {
        SceneManager.LoadScene("location4");
    }

    private void Location3()
    {
        SceneManager.LoadScene("location3");
    }

    private void Location2()
    {
        SceneManager.LoadScene("location2");
    }

    private void Location1()
    {
        SceneManager.LoadScene("location1");
    }
}
