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
        p1 = GameObject.Find("Player1CatFighter").GetComponent<Player1Controls>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2HurtBox") && !gc.roundFinished)
        {
            gc.Player1WinsRound();
        }
    }
}
