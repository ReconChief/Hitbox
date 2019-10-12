using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRight : MonoBehaviour
{
    [Header("Script Variables")]
    //Using Variables from other Objects
    private Player1Controls player1;

    private Player2Controls player2;

    private void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1Controls>();
        player2 = GameObject.Find("Player2").GetComponent<Player2Controls>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1Movement"))
        {
            player1.moveRight = false;
        }
        
        if (collision.CompareTag("Player2Movement"))
        {
            player2.moveRight = false;
        }        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player1Movement"))
        {
            player1.moveRight = true;
        }

        
        if (collision.CompareTag("Player2Movement"))
        {
            player2.moveRight = true;
        }        
    }
}
