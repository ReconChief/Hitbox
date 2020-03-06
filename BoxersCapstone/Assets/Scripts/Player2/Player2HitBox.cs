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
        p2 = GameObject.Find("Player2CatFighter").GetComponent<Player2Controls>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1HurtBox") && !gc.roundFinished)
        {
            gc.Player2WinsRound();
        }
    }
}
