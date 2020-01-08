using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject titleScreen;

    public GameObject controlScreen;
    public GameObject keyboardScreen;
    public GameObject controllerScreen;
    public GameObject optionsScreen;

    public GameObject stageSelectScreen;

    //Buttons For Next Screens
    [Header("Buttons")]
    public GameObject mainMenuButton;
    public GameObject controlsButton;
    public GameObject returnKeyButton;
    public GameObject returnControllerButton;
    public GameObject stageSelectButton;

    public void returnToTitle()
    {
        titleScreen.SetActive(true);
        controlScreen.SetActive(false);
        stageSelectScreen.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(mainMenuButton,null);
    }

    public void returnToControls()
    {
        optionsScreen.SetActive(true);
        keyboardScreen.SetActive(false);
        controllerScreen.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(controlsButton, null);
    }

    public void Controls()
    {
        titleScreen.SetActive(false);
        controlScreen.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(controlsButton,null);
    }

    public void keyboardControls()
    {
        optionsScreen.SetActive(false);
        keyboardScreen.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(returnKeyButton, null);
;    }

    public void controllerControls()
    {
        optionsScreen.SetActive(false);
        controllerScreen.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(returnControllerButton,null);
    }

    public void StageSelect()
    {
        titleScreen.SetActive(false);
        stageSelectScreen.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(stageSelectButton,null);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
