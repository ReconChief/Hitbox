using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRight : MonoBehaviour
{
    [Header("Game Object Variables")]
    //Using Variables from other Objects
    private GameObject player1Object;
    private Player1Controls player1;

    private GameObject player2Object;
    private Player2Controls player2;

    private void Start()
    {
        player1Object = GameObject.FindGameObjectWithTag("Player1");
        player1 = player1Object.GetComponent<Player1Controls>();

        player2Object = GameObject.FindGameObjectWithTag("Player2");
        player2 = player2Object.GetComponent<Player2Controls>();
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
