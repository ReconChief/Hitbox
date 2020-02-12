using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelection : MonoBehaviour
{
    public GameObject[] stages = new GameObject[3];

    private TitleScreen titleScreen;

    private int currentNumber = 0;

    private void Start()
    {
        if (string.Equals(SceneManager.GetActiveScene().name, "Game"))
        {
            RecoverGameData();
        }

        titleScreen = GameObject.FindGameObjectWithTag("GameController").GetComponent<TitleScreen>();
    }

    private void Update()
    {
        switch (currentNumber)
        {
            case 0:
                stages[0].SetActive(true);
                stages[1].SetActive(false);
                stages[2].SetActive(false);
                break;
            case 1:
                stages[0].SetActive(false);
                stages[1].SetActive(true);
                stages[2].SetActive(false);
                break;
            case 2:
                stages[0].SetActive(false);
                stages[1].SetActive(false);
                stages[2].SetActive(true);
                break;
        }
    }

    public void nextStage()
    {
        currentNumber++;

        if (currentNumber > 2)
        {
            currentNumber = 0;
        }
    }

    public void previousStage()
    {
        currentNumber--;

        if (currentNumber < 0)
        {
            currentNumber = 2;
        }
    }

    public void catSelection()
    {
        SaveGameData();
        titleScreen.CatSelect();
    }

    private void SaveGameData()
    {
        PlayerPrefs.SetInt("stageNumber", currentNumber);
    }

    private void RecoverGameData()
    {
        currentNumber = PlayerPrefs.GetInt("stageNumber");
    }    
}
