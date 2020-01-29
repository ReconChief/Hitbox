using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatSelection : MonoBehaviour
{
    public GameObject[] player1Cats = new GameObject[8];
    public GameObject[] player2Cats = new GameObject[8];

    private int player1CatNumber = 0;
    private int player2CatNumber = 0;

    void Start()
    {
        if (string.Equals(SceneManager.GetActiveScene().name, "Game"))
        {
            RecoverGameData();
        }
    }

    public void P1NextCat()
    {
        player1CatNumber++;

        if (player1CatNumber > 7)
        {
            player1CatNumber = 0;
        }
    }

    public void P1PreviousCat()
    {
        player1CatNumber--;

        if (player1CatNumber < 0)
        {
            player1CatNumber = 7;
        }
    }

    public void P2NextCat()
    {
        player2CatNumber++;

        if (player2CatNumber > 7)
        {
            player2CatNumber = 0;
        }
    }

    public void P2PreviousCat()
    {
        player2CatNumber--;

        if (player2CatNumber < 0)
        {
            player2CatNumber = 7;
        }
    }

    private void SaveGameData()
    {
        PlayerPrefs.SetInt("player1Cat", player1CatNumber);
        PlayerPrefs.SetInt("player2Cat", player2CatNumber);
    }

    private void RecoverGameData()
    {
        player1CatNumber = PlayerPrefs.GetInt("player1Cat");
        player2CatNumber = PlayerPrefs.GetInt("player2Cat");
    }
}
