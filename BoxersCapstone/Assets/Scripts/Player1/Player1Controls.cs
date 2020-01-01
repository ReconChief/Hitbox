﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    //Controls
    [Header ("Player Variables")]
    public float playerSpeed = 3.5f;
    public float startUpFrames = 5.0f;
    public float standInputTime = 1.0f;
    public float lowInputTime = 1.0f;
    public float distanceFromMid = -1.2f; //starting point distance from middle 
    public bool moveLeft = true;
    public bool moveRight = true;

    //Attacks
    [Header("Player Attacks")]
    public bool standLightP = false;
    public bool standFierceP = false;
    public bool lowLightP = false;
    public bool lowFierceP = false;

    private GameObject gameController;
    private GameController gc;

    public GameObject Frame0;

    //Frames
    [Header("Frames")]
    #region Stand Frames
    public GameObject standLightFrame1;
    public GameObject standLightFrame2;
    public GameObject standLightFrame3;

    public GameObject standFierceFrame1;
    public GameObject standFierceFrame2;
    public GameObject standFierceFrame3;
    public GameObject standFierceFrame4;
    public GameObject standFierceFrame5;
    public GameObject standFierceFrame6;
    #endregion

    #region Low Frames
    public GameObject lowLightFrame1;
    public GameObject lowLightFrame2;
    public GameObject lowLightFrame3;

    public GameObject lowFierceFrame1;
    public GameObject lowFierceFrame2;
    public GameObject lowFierceFrame3;
    public GameObject lowFierceFrame4;
    public GameObject lowFierceFrame5;
    public GameObject lowFierceFrame6;
    #endregion

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gc = gameController.GetComponent<GameController>();
    }

    void Update()
    {
        #region KeyBoard Controls

        #region Movement
        if (Input.GetKey(KeyCode.D) && !gc.roundFinished && moveRight) //Right
        {
            if (Input.GetKey(KeyCode.Q)) // Run
            {
                Vector3 movement = new Vector3(1f, 0f, 0f);
                transform.position += movement * Time.deltaTime * 5.0f;
            }

            else
            {
                Vector3 movement = new Vector3(1f, 0f, 0f);
                transform.position += movement * Time.deltaTime * playerSpeed;
            }

            if (distanceFromMid < 3.3)
            {
                distanceFromMid += Time.deltaTime;
            }

            else if(distanceFromMid >= 3.3)
            {
                distanceFromMid = 3.29f;
            }
        }

        else if (Input.GetKey(KeyCode.A) && !gc.roundFinished && moveLeft) //Left
        {
            Vector3 movement = new Vector3(-1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * playerSpeed;
            
            if (distanceFromMid > -3.2)
            {
                distanceFromMid -= Time.deltaTime;
            }

            else if (distanceFromMid <= -3.2)
            {

                distanceFromMid = -3.19f;
            }
        }
        #endregion

        #region Input Time
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !gc.roundFinished) //Input Time to determine Light or Fierce Punch
        {
            standInputTime -= Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !gc.roundFinished) //Input Time to determine Low Light or Low Fierce Punch
        {
            lowInputTime -= Time.deltaTime;
        }
        #endregion

        //Stand Claws
        if (Input.GetKeyUp(KeyCode.W) && !Input.GetKeyUp(KeyCode.S) && startUpFrames == 5 && standInputTime > 0.6f && !gc.roundFinished) //Light Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            standLightP = true;
        }

        else if (Input.GetKeyUp(KeyCode.W) && !Input.GetKeyUp(KeyCode.S) && startUpFrames == 5 && standInputTime < 0.6f && !gc.roundFinished) //Fierce Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            standFierceP = true;
        }

        //Low Claws
        if (Input.GetKeyUp(KeyCode.S) && !Input.GetKeyUp(KeyCode.W) && startUpFrames == 5 && lowInputTime > 0.6f && !gc.roundFinished) //Light Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            lowLightP = true;
        }

        else if (Input.GetKeyUp(KeyCode.S) && !Input.GetKeyUp(KeyCode.W) && startUpFrames == 5 && lowInputTime < 0.6f && !gc.roundFinished) //Fierce Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            lowFierceP = true;
        }
        #endregion

        #region Controller Controls
        #region Movement
        if (Input.GetAxis("P1DPad") == 1 && !gc.roundFinished && moveRight) //Right
        {
            if (Input.GetKey(KeyCode.Q)) // Run
            {
                Vector3 movement = new Vector3(1f, 0f, 0f);
                transform.position += movement * Time.deltaTime * 5.0f;
            }

            else
            {
                Vector3 movement = new Vector3(1f, 0f, 0f);
                transform.position += movement * Time.deltaTime * playerSpeed;
            }

            if (distanceFromMid < 3.3)
            {
                distanceFromMid += Time.deltaTime;
            }

            else if (distanceFromMid >= 3.3)
            {
                distanceFromMid = 3.29f;
            }
        }

        else if (Input.GetAxis("P1DPad") == -1 && !gc.roundFinished && moveLeft) //Left
        {
            Vector3 movement = new Vector3(-1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * playerSpeed;

            if (distanceFromMid > -3.2)
            {
                distanceFromMid -= Time.deltaTime;
            }

            else if (distanceFromMid <= -3.2)
            {

                distanceFromMid = -3.19f;
            }
        }
        #endregion

        #region Input Time
        if (Input.GetKey(KeyCode.Joystick1Button2) && !Input.GetKey(KeyCode.Joystick1Button0) && !gc.roundFinished) //Input Time to determine Light or Fierce Punch
        {
            Debug.Log("Works");
            standInputTime -= Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.Joystick1Button0) && !Input.GetKey(KeyCode.Joystick1Button2) && !gc.roundFinished) //Input Time to determine Low Light or Low Fierce Punch
        {
            lowInputTime -= Time.deltaTime;
        }
        #endregion

        //Stand Claws
        if (Input.GetKeyUp(KeyCode.Joystick1Button2) && !Input.GetKeyUp(KeyCode.Joystick1Button0) && startUpFrames == 5 && standInputTime > 0.6f && !gc.roundFinished) //Light Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            standLightP = true;
        }

        else if (Input.GetKeyUp(KeyCode.Joystick1Button2) && !Input.GetKeyUp(KeyCode.Joystick1Button0) && startUpFrames == 5 && standInputTime < 0.6f && !gc.roundFinished) //Fierce Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            standFierceP = true;
        }

        //Low Claws
        if (Input.GetKeyUp(KeyCode.Joystick1Button0) && !Input.GetKeyUp(KeyCode.Joystick1Button2) && startUpFrames == 5 && lowInputTime > 0.6f && !gc.roundFinished) //Light Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            lowLightP = true;
        }

        else if (Input.GetKeyUp(KeyCode.Joystick1Button0) && !Input.GetKeyUp(KeyCode.Joystick1Button2) && startUpFrames == 5 && lowInputTime < 0.6f && !gc.roundFinished) //Fierce Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            lowFierceP = true;
        }
        #endregion

        #region Stand Light/Fierce Punch

        //Stand Light Punch Function
        if (startUpFrames < 5 && standLightP)
        {
            Frame0.SetActive(false);
            lowLightFrame1.SetActive(false);

            startUpFrames -= Time.deltaTime;

            if (startUpFrames > 4.8f)
            {
                standLightFrame1.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.6f)
            {
                standLightFrame1.SetActive(false);
                standLightFrame2.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.4f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.2f)
            {
                standLightFrame2.SetActive(false);
                standLightFrame3.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.8f)
            {
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames < 3.8f)
            {
                standLightFrame3.SetActive(false);
                Frame0.SetActive(true);

                startUpFrames = 5.0f;
                playerSpeed = 3.5f;
                standInputTime = 1.0f;
                standLightP = false;
            }
        }

        //Stand Fierce Punch Function
        if (startUpFrames < 5 && standFierceP)
        {
            Frame0.SetActive(false);
            lowLightFrame1.SetActive(false);

            startUpFrames -= Time.deltaTime;

            if (startUpFrames > 4.8f)
            {
                standFierceFrame1.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.6f)
            {
                standFierceFrame1.SetActive(false);
                standFierceFrame2.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.4f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.2f)
            {
                standFierceFrame2.SetActive(false);
                standFierceFrame3.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.9f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.7f)
            {
                standFierceFrame3.SetActive(false);
                standFierceFrame4.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.5f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.3f)
            {
                standFierceFrame4.SetActive(false);
                standFierceFrame5.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames > 3.0f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 2.8f)
            {
                standFierceFrame5.SetActive(false);
                standFierceFrame6.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 2.0f)
            {
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames < 2.0f)
            {
                Frame0.SetActive(true);
                standFierceFrame6.SetActive(false);

                startUpFrames = 5.0f;
                playerSpeed = 3.5f;
                standInputTime = 1.0f;
                standFierceP = false;
            }
        }

       #endregion

        #region Low Light/Fierce Punch
        //Low Light Punch Function
        if (startUpFrames < 5 && lowLightP)
        {
            Frame0.SetActive(false);

            startUpFrames -= Time.deltaTime;

            if (startUpFrames > 4.8f)
            {
                lowLightFrame1.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.6f)
            {
                lowLightFrame1.SetActive(false);
                lowLightFrame2.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.4f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.2f)
            {
                lowLightFrame2.SetActive(false);
                lowLightFrame3.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.8f)
            {
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames < 3.8f)
            {
                lowLightFrame3.SetActive(false);
                Frame0.SetActive(true);

                startUpFrames = 5.0f;
                playerSpeed = 3.5f;
                lowInputTime = 1.0f;
                lowLightP = false;
            }
        }

        //Low Fierce Punch Function
        if (startUpFrames < 5 && lowFierceP)
        {
            Frame0.SetActive(false);

            startUpFrames -= Time.deltaTime;

            if (startUpFrames > 4.8f)
            {
                lowFierceFrame1.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.6f)
            {
                lowFierceFrame1.SetActive(false);
                lowFierceFrame2.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.4f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.2f)
            {
                lowFierceFrame2.SetActive(false);
                lowFierceFrame3.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.9f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.7f)
            {
                lowFierceFrame3.SetActive(false);
                lowFierceFrame4.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.5f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.3f)
            {
                lowFierceFrame4.SetActive(false);
                lowFierceFrame5.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames > 3.0f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 2.8f)
            {
                lowFierceFrame5.SetActive(false);
                lowFierceFrame6.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 2.0f)
            {
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames < 2.0f)
            {
                lowFierceFrame6.SetActive(false);

                Frame0.SetActive(true);

                startUpFrames = 5.0f;
                playerSpeed = 3.5f;
                lowInputTime = 1.0f;
                lowFierceP = false;
            }
        }

        #endregion
    }
}
