using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1HitBox : MonoBehaviour
{ 
    private GameController gc;
    private Player1Controls p1;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        p1 = GameObject.Find("Player1").GetComponent<Player1Controls>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2HurtBox"))
        {
            /*
            p1.standLightP = false;
            p1.standFierceP = false;
            p1.lowLightP = false;
            p1.lowFierceP = false;

            p1.startUpFrames = 5.0f;
            p1.standInputTime = 1.0f;
            p1.lowInputTime = 1.0f;
            */
            gc.Player1WinsRound();
        }
    }
}
