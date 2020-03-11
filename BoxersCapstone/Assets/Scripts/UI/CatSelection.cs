using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatSelection : MonoBehaviour
{
    public GameObject[] player1Cats = new GameObject[8];
    public GameObject[] player2Cats = new GameObject[8];

    public GameObject[] player1ReadyOrNot = new GameObject[2];
    public GameObject[] player2ReadyOrNot = new GameObject[2];

    private TitleScreen titleScreen;

    private int player1CatNumber = 0;
    private int player2CatNumber = 1;

    private bool p1Ready = false;
    private bool p2Ready = false;

    private bool check = false;

    void Start()
    {
        if (string.Equals(SceneManager.GetActiveScene().name, "Game") || string.Equals(SceneManager.GetActiveScene().name, "Player1W")
            || string.Equals(SceneManager.GetActiveScene().name, "Player2W"))
        {
            RecoverGameData();
        }

        if (string.Equals(SceneManager.GetActiveScene().name, "TitleScreen"))
        {
            titleScreen = GameObject.FindGameObjectWithTag("GameController").GetComponent<TitleScreen>();
        }
    }

    private void Update()
    {
        if (string.Equals(SceneManager.GetActiveScene().name, "TitleScreen"))
        {
            if (titleScreen.catSelectionScreen.activeSelf)
            {
                #region Cat Selection
                //Left and Right Cat Selection
                if (Input.GetKeyUp(KeyCode.Joystick1Button4)) //Player 1 LB
                {
                    P1PreviousCat();
                }

                else if (Input.GetKeyUp(KeyCode.Joystick1Button5)) //Player 1 RB
                {
                    P1NextCat();
                }

                if (Input.GetKeyUp(KeyCode.A))
                {
                    P1PreviousCat();
                }

                else if (Input.GetKeyUp(KeyCode.D))
                {
                    P1NextCat();
                }

                if (Input.GetKeyUp(KeyCode.Joystick2Button4)) //Player 2 LB
                {
                    P2PreviousCat();
                }

                else if (Input.GetKeyUp(KeyCode.Joystick2Button5)) //Player 2 RB
                {
                    P2NextCat();
                }

                if (Input.GetKeyUp(KeyCode.LeftArrow)) //Player 2 LB
                {
                    P2PreviousCat();
                }

                else if (Input.GetKeyUp(KeyCode.RightArrow)) //Player 2 RB
                {
                    P2NextCat();
                }
                #endregion

                //Ready or Not
                if (Input.GetKeyUp(KeyCode.Joystick1Button0)) //Player 1 A Button
                {
                    p1Ready = true;
                    player1ReadyOrNot[0].SetActive(false);
                    player1ReadyOrNot[1].SetActive(true);
                }

                if (Input.GetKeyUp(KeyCode.W))
                {
                    p1Ready = true;
                    player1ReadyOrNot[0].SetActive(false);
                    player1ReadyOrNot[1].SetActive(true);
                }

                if (Input.GetKeyUp(KeyCode.Joystick2Button0)) //Player 2 A Button
                {
                    p2Ready = true;
                    player2ReadyOrNot[0].SetActive(false);
                    player2ReadyOrNot[1].SetActive(true);
                }

                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    p2Ready = true;
                    player2ReadyOrNot[0].SetActive(false);
                    player2ReadyOrNot[1].SetActive(true);
                }

                //Player 1 Cats
                switch (player1CatNumber)
                {
                    case 0:
                        player1Cats[0].SetActive(true);
                        player1Cats[1].SetActive(false);
                        player1Cats[2].SetActive(false);
                        player1Cats[3].SetActive(false);
                        player1Cats[4].SetActive(false);
                        player1Cats[5].SetActive(false);
                        player1Cats[6].SetActive(false);
                        player1Cats[7].SetActive(false);
                        break;
                    case 1:
                        player1Cats[0].SetActive(false);
                        player1Cats[1].SetActive(true);
                        player1Cats[2].SetActive(false);
                        player1Cats[3].SetActive(false);
                        player1Cats[4].SetActive(false);
                        player1Cats[5].SetActive(false);
                        player1Cats[6].SetActive(false);
                        player1Cats[7].SetActive(false);
                        break;
                    case 2:
                        player1Cats[0].SetActive(false);
                        player1Cats[1].SetActive(false);
                        player1Cats[2].SetActive(true);
                        player1Cats[3].SetActive(false);
                        player1Cats[4].SetActive(false);
                        player1Cats[5].SetActive(false);
                        player1Cats[6].SetActive(false);
                        player1Cats[7].SetActive(false);
                        break;
                    case 3:
                        player1Cats[0].SetActive(false);
                        player1Cats[1].SetActive(false);
                        player1Cats[2].SetActive(false);
                        player1Cats[3].SetActive(true);
                        player1Cats[4].SetActive(false);
                        player1Cats[5].SetActive(false);
                        player1Cats[6].SetActive(false);
                        player1Cats[7].SetActive(false);
                        break;
                    case 4:
                        player1Cats[0].SetActive(false);
                        player1Cats[1].SetActive(false);
                        player1Cats[2].SetActive(false);
                        player1Cats[3].SetActive(false);
                        player1Cats[4].SetActive(true);
                        player1Cats[5].SetActive(false);
                        player1Cats[6].SetActive(false);
                        player1Cats[7].SetActive(false);
                        break;
                    case 5:
                        player1Cats[0].SetActive(false);
                        player1Cats[1].SetActive(false);
                        player1Cats[2].SetActive(false);
                        player1Cats[3].SetActive(false);
                        player1Cats[4].SetActive(false);
                        player1Cats[5].SetActive(true);
                        player1Cats[6].SetActive(false);
                        player1Cats[7].SetActive(false);
                        break;
                    case 6:
                        player1Cats[0].SetActive(false);
                        player1Cats[1].SetActive(false);
                        player1Cats[2].SetActive(false);
                        player1Cats[3].SetActive(false);
                        player1Cats[4].SetActive(false);
                        player1Cats[5].SetActive(false);
                        player1Cats[6].SetActive(true);
                        player1Cats[7].SetActive(false);
                        break;
                    case 7:
                        player1Cats[0].SetActive(false);
                        player1Cats[1].SetActive(false);
                        player1Cats[2].SetActive(false);
                        player1Cats[3].SetActive(false);
                        player1Cats[4].SetActive(false);
                        player1Cats[5].SetActive(false);
                        player1Cats[6].SetActive(false);
                        player1Cats[7].SetActive(true);
                        break;
                }

                //Player 2 Cats
                switch (player2CatNumber)
                {
                    case 0:
                        player2Cats[0].SetActive(true);
                        player2Cats[1].SetActive(false);
                        player2Cats[2].SetActive(false);
                        player2Cats[3].SetActive(false);
                        player2Cats[4].SetActive(false);
                        player2Cats[5].SetActive(false);
                        player2Cats[6].SetActive(false);
                        player2Cats[7].SetActive(false);
                        break;
                    case 1:
                        player2Cats[0].SetActive(false);
                        player2Cats[1].SetActive(true);
                        player2Cats[2].SetActive(false);
                        player2Cats[3].SetActive(false);
                        player2Cats[4].SetActive(false);
                        player2Cats[5].SetActive(false);
                        player2Cats[6].SetActive(false);
                        player2Cats[7].SetActive(false);
                        break;
                    case 2:
                        player2Cats[0].SetActive(false);
                        player2Cats[1].SetActive(false);
                        player2Cats[2].SetActive(true);
                        player2Cats[3].SetActive(false);
                        player2Cats[4].SetActive(false);
                        player2Cats[5].SetActive(false);
                        player2Cats[6].SetActive(false);
                        player2Cats[7].SetActive(false);
                        break;
                    case 3:
                        player2Cats[0].SetActive(false);
                        player2Cats[1].SetActive(false);
                        player2Cats[2].SetActive(false);
                        player2Cats[3].SetActive(true);
                        player2Cats[4].SetActive(false);
                        player2Cats[5].SetActive(false);
                        player2Cats[6].SetActive(false);
                        player2Cats[7].SetActive(false);
                        break;
                    case 4:
                        player2Cats[0].SetActive(false);
                        player2Cats[1].SetActive(false);
                        player2Cats[2].SetActive(false);
                        player2Cats[3].SetActive(false);
                        player2Cats[4].SetActive(true);
                        player2Cats[5].SetActive(false);
                        player2Cats[6].SetActive(false);
                        player2Cats[7].SetActive(false);
                        break;
                    case 5:
                        player2Cats[0].SetActive(false);
                        player2Cats[1].SetActive(false);
                        player2Cats[2].SetActive(false);
                        player2Cats[3].SetActive(false);
                        player2Cats[4].SetActive(false);
                        player2Cats[5].SetActive(true);
                        player2Cats[6].SetActive(false);
                        player2Cats[7].SetActive(false);
                        break;
                    case 6:
                        player2Cats[0].SetActive(false);
                        player2Cats[1].SetActive(false);
                        player2Cats[2].SetActive(false);
                        player2Cats[3].SetActive(false);
                        player2Cats[4].SetActive(false);
                        player2Cats[5].SetActive(false);
                        player2Cats[6].SetActive(true);
                        player2Cats[7].SetActive(false);
                        break;
                    case 7:
                        player2Cats[0].SetActive(false);
                        player2Cats[1].SetActive(false);
                        player2Cats[2].SetActive(false);
                        player2Cats[3].SetActive(false);
                        player2Cats[4].SetActive(false);
                        player2Cats[5].SetActive(false);
                        player2Cats[6].SetActive(false);
                        player2Cats[7].SetActive(true);
                        break;
                }

                //Return to Stage Select or Cancel
                if (Input.GetKeyUp(KeyCode.S) && !p1Ready)
                {
                    check = false;
                    titleScreen.returnToStageSelect();
                }

                else if (Input.GetKeyUp(KeyCode.S) && p1Ready)
                {
                    p1Ready = false;
                }

                if (Input.GetKeyUp(KeyCode.Joystick1Button2) && !p1Ready) //Player 1 X Button
                {
                    check = false;
                    titleScreen.returnToStageSelect();
                }

                else if (Input.GetKeyUp(KeyCode.Joystick1Button2) && p1Ready) //Player 1 X Button
                {
                    p1Ready = false;
                }

                if (Input.GetKeyUp(KeyCode.DownArrow) && !p2Ready)
                {
                    check = false;
                    titleScreen.returnToStageSelect();
                }

                else if (Input.GetKeyUp(KeyCode.DownArrow) && p2Ready)
                {
                    p2Ready = false;
                }

                if (Input.GetKeyUp(KeyCode.Joystick2Button2) && !p2Ready) //Player 2 X Button
                {
                    check = false;
                    titleScreen.returnToStageSelect();
                }

                else if (Input.GetKeyUp(KeyCode.Joystick2Button2) && p2Ready) //Player 2 X Button
                {
                    p2Ready = false;
                }

                #region Check Marks
                if (!p1Ready) //If P1 is not ready, X
                {
                    player1ReadyOrNot[0].SetActive(true);
                    player1ReadyOrNot[1].SetActive(false);
                }

                else //If P1 is ready, check mark
                {
                    player1ReadyOrNot[0].SetActive(false);
                    player1ReadyOrNot[1].SetActive(true);
                }

                if (!p2Ready) // If P2 is not ready, X
                {
                    player2ReadyOrNot[0].SetActive(true);
                    player2ReadyOrNot[1].SetActive(false);
                }

                else //If P2 is ready, check mark
                {
                    player2ReadyOrNot[0].SetActive(false);
                    player2ReadyOrNot[1].SetActive(true);
                }
                #endregion

                if (p1Ready && p2Ready)
                {
                    StartGame();
                }
            }
        }

        else if(string.Equals(SceneManager.GetActiveScene().name, "Player1W"))
        {
            //Player 1 Cats
            switch (player1CatNumber)
            {
                case 0:
                    player1Cats[0].SetActive(true);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 1:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(true);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 2:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(true);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 3:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(true);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 4:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(true);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 5:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(true);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 6:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(true);
                    player1Cats[7].SetActive(false);
                    break;
                case 7:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(true);
                    break;
            }
        }

        else if (string.Equals(SceneManager.GetActiveScene().name, "Player2W"))
        {
            //Player 2 Cats
            switch (player2CatNumber)
            {
                case 0:
                    player2Cats[0].SetActive(true);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 1:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(true);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 2:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(true);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 3:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(true);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 4:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(true);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 5:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(true);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 6:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(true);
                    player2Cats[7].SetActive(false);
                    break;
                case 7:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(true);
                    break;
            }
        }

        else if (string.Equals(SceneManager.GetActiveScene().name, "Game"))
        {
            //Player 1 Cats
            switch (player1CatNumber)
            {
                case 0:
                    player1Cats[0].SetActive(true);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 1:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(true);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 2:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(true);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 3:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(true);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 4:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(true);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 5:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(true);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(false);
                    break;
                case 6:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(true);
                    player1Cats[7].SetActive(false);
                    break;
                case 7:
                    player1Cats[0].SetActive(false);
                    player1Cats[1].SetActive(false);
                    player1Cats[2].SetActive(false);
                    player1Cats[3].SetActive(false);
                    player1Cats[4].SetActive(false);
                    player1Cats[5].SetActive(false);
                    player1Cats[6].SetActive(false);
                    player1Cats[7].SetActive(true);
                    break;
            }

            //Player 2 Cats
            switch (player2CatNumber)
            {
                case 0:
                    player2Cats[0].SetActive(true);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 1:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(true);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 2:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(true);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 3:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(true);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 4:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(true);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 5:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(true);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(false);
                    break;
                case 6:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(true);
                    player2Cats[7].SetActive(false);
                    break;
                case 7:
                    player2Cats[0].SetActive(false);
                    player2Cats[1].SetActive(false);
                    player2Cats[2].SetActive(false);
                    player2Cats[3].SetActive(false);
                    player2Cats[4].SetActive(false);
                    player2Cats[5].SetActive(false);
                    player2Cats[6].SetActive(false);
                    player2Cats[7].SetActive(true);
                    break;
            }
        }

        if (!check && Input.GetJoystickNames().Length > 0)
        {
            if (p1Ready)
            {
                check = true;
                p1Ready = false;
            }

            else if (Input.GetJoystickNames().Length > 1)
            {
                if (p1Ready || p2Ready)
                {
                    check = true;
                    p1Ready = false;
                    p2Ready = false;
                }
            }
        }
    }

    public void P1NextCat()
    {
        p1Ready = false;

        player1CatNumber++;

        if (player1CatNumber > 7)
        {
            player1CatNumber = 0;
        }
    }

    public void P1PreviousCat()
    {
        p1Ready = false;

        player1CatNumber--;

        if (player1CatNumber < 0)
        {
            player1CatNumber = 7;
        }
    }

    public void P2NextCat()
    {
        p2Ready = false;

        player2CatNumber++;

        if (player2CatNumber > 7)
        {
            player2CatNumber = 0;
        }
    }

    public void P2PreviousCat()
    {
        p2Ready = false;

        player2CatNumber--;

        if (player2CatNumber < 0)
        {
            player2CatNumber = 7;
        }
    }

    public void StartGame()
    {
        SaveGameData();
        SceneManager.LoadScene("Game");
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
