using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject controlScreen;

    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Controls()
    {

        titleScreen.SetActive(false);
        controlScreen.SetActive(true);
    }

    public void turnOffControls()
    {
        titleScreen.SetActive(true);
        controlScreen.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
