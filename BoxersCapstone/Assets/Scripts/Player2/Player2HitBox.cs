using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2HitBox : MonoBehaviour
{
    private GameController gc;
    private Player2Controls p2;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        p2 = GameObject.Find("Player2").GetComponent<Player2Controls>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1HurtBox"))
        {
            /*
            p2.standLightP = false;
            p2.standFierceP = false;
            p2.lowLightP = false;
            p2.lowFierceP = false;

            p2.startUpFrames = 5.0f;
            p2.standInputTime = 1.0f;
            p2.lowInputTime = 1.0f;
            */
            gc.Player2WinsRound();
        }
    }
}
