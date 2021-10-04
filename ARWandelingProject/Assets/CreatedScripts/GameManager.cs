using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
    Location1();
    Location2();
    Location3();
    Location4();
    Location5();
    Exit();       
    }

    private void Exit()
    {
        SceneManager.LoadScene("");
    }

    private void Location5()
    {
        SceneManager.LoadScene("");
    }

    private void Location4()
    {
        SceneManager.LoadScene("");
    }

    private void Location3()
    {
        SceneManager.LoadScene("");
    }

    private void Location2()
    {
        SceneManager.LoadScene("");
    }

    private void Location1()
    {
        SceneManager.LoadScene("");
    }
}
