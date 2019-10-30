using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
