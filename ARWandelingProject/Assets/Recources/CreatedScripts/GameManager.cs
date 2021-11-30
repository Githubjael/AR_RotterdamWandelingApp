using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public void SampleScene()
    {
        SceneManager.LoadScene("Loc1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
