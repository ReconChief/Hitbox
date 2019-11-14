using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLeft : MonoBehaviour
{
    [Header("Script Variables")]
    //Using Variables from other Objects
    private Player1Controls player1;

    private Player2Controls player2;

    private void Start()
    {
        player1 = GameObject.Find("Player1Cat").GetComponent<Player1Controls>();
        player2 = GameObject.Find("Player2Cat").GetComponent<Player2Controls>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1Movement"))
        {
            player1.moveLeft = false;
        }

        if (collision.CompareTag("Player2Movement"))
        {
            player2.moveLeft = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player1Movement"))
        {
            player1.moveLeft = true;
        }
        
        if (collision.CompareTag("Player2Movement"))
        {
            player2.moveLeft = true;
        }
    }
}