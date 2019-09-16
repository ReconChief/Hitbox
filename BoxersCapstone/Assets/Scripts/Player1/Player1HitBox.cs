using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1HitBox : MonoBehaviour
{ 
    private GameObject gameController;
    private GameController gc;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gc = gameController.GetComponent<GameController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2HurtBox"))
        {
            gc.Player1WinsRound();
        }
    }
}
