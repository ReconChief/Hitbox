using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject titleScreen;

    public GameObject controlScreen;
    public GameObject keyboardScreen;
    public GameObject controllerScreen;
    public GameObject optionsScreen;

    public GameObject stageSelectScreen;

    public void returnToTitle()
    {
        titleScreen.SetActive(true);
        controlScreen.SetActive(false);
        stageSelectScreen.SetActive(false);
    }

    public void returnToControls()
    {
        optionsScreen.SetActive(true);
        keyboardScreen.SetActive(false);
        controllerScreen.SetActive(false);
    }

    public void Controls()
    {
        titleScreen.SetActive(false);
        controlScreen.SetActive(true);
    }

    public void keyboardControls()
    {
        optionsScreen.SetActive(false);
        keyboardScreen.SetActive(true);
    }

    public void controllerControls()
    {
        optionsScreen.SetActive(false);
        controllerScreen.SetActive(true);
    }

    public void StageSelect()
    {
        titleScreen.SetActive(false);
        stageSelectScreen.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
