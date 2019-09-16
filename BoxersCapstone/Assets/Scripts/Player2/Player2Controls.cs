using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controls : MonoBehaviour
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

    //Frames
    [Header("Frames")]
    #region Stand Frames
    public GameObject standFrame1;
    public GameObject standFrame2;
    public GameObject standFrame3;
    public GameObject standFrame4;
    public GameObject standFrame5;
    public GameObject standFrame6;
    #endregion

    #region Low Frames
    public GameObject lowFrame1;
    public GameObject lowFrame2;
    public GameObject lowFrame3;
    public GameObject lowFrame4;
    public GameObject lowFrame5;
    public GameObject lowFrame6;
    #endregion

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gc = gameController.GetComponent<GameController>();
    }

    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.Keypad6) && !gc.roundFinished && moveRight) //Right
        {
            Vector3 movement = new Vector3(1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * playerSpeed;

            if (distanceFromMid < 3.3)
            {
                distanceFromMid -= Time.deltaTime;
            }

            else if (distanceFromMid >= -3.2)
            {
                distanceFromMid = -3.19f;
            }
        }

        else if (Input.GetKey(KeyCode.Keypad4) && !gc.roundFinished && moveLeft) //Left
        {
            Vector3 movement = new Vector3(-1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * playerSpeed;
            if (distanceFromMid > -3.2)
            {
                distanceFromMid += Time.deltaTime;
            }

            else if (distanceFromMid <= 3.3)
            {
                distanceFromMid = 3.29f;
            }
        }

        if (Input.GetKey(KeyCode.Keypad8) && !Input.GetKey(KeyCode.Keypad5) && !gc.roundFinished) //Input Time to determine Light or Fierce Punch
        {
            standInputTime -= Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.Keypad5) && !Input.GetKey(KeyCode.Keypad8) && !gc.roundFinished) //Input Time to determine Low Light or Low Fierce Punch
        {
            lowInputTime -= Time.deltaTime;
        }

        #region Stand Light/Fierce Punch
        if (Input.GetKeyUp(KeyCode.Keypad8) && !Input.GetKeyUp(KeyCode.Keypad5) && startUpFrames == 5 && standInputTime > 0.6f && !gc.roundFinished) //Light Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            standLightP = true;
        }

        else if (Input.GetKeyUp(KeyCode.Keypad8) && !Input.GetKeyUp(KeyCode.Keypad5) && startUpFrames == 5 && standInputTime < 0.6f && !gc.roundFinished) //Fierce Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            standFierceP = true;
        }

        //Stand Light Punch Function
        if (startUpFrames < 5 && standLightP)
        {
            standFrame1.SetActive(true);
            lowFrame1.SetActive(false);

            startUpFrames -= Time.deltaTime;

            if (startUpFrames > 4.7f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.3f)
            {
                standFrame2.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.1f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.9f)
            {
                standFrame3.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.2f)
            {
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames < 3.2f)
            {
                standFrame2.SetActive(false);
                standFrame3.SetActive(false);
                standFrame4.SetActive(false);
                standFrame5.SetActive(false);
                standFrame6.SetActive(false);

                startUpFrames = 5.0f;
                playerSpeed = 3.5f;
                standInputTime = 1.0f;
                standLightP = false;
            }
        }

        //Stand Fierce Punch Function
        if (startUpFrames < 5 && standFierceP)
        {
            standFrame1.SetActive(true);
            lowFrame1.SetActive(false);

            startUpFrames -= Time.deltaTime;

            if (startUpFrames > 4.7f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.3f)
            {
                standFrame2.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.1f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.9f)
            {
                standFrame3.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.6f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.2f)
            {
                standFrame4.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 2.8f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 2.5f)
            {
                standFrame5.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames > 2.1f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 1.8f)
            {
                standFrame6.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 0.8f)
            {
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames < 0.8f)
            {
                standFrame2.SetActive(false);
                standFrame3.SetActive(false);
                standFrame4.SetActive(false);
                standFrame5.SetActive(false);
                standFrame6.SetActive(false);

                startUpFrames = 5.0f;
                playerSpeed = 3.5f;
                standInputTime = 1.0f;
                standFierceP = false;
            }
        }

        #endregion

        #region Low Light/Fierce Punch
        if (Input.GetKeyUp(KeyCode.Keypad5) && !Input.GetKeyUp(KeyCode.Keypad8) && startUpFrames == 5 && lowInputTime > 0.6f && !gc.roundFinished) //Light Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            lowLightP = true;
        }

        else if (Input.GetKeyUp(KeyCode.Keypad5) && !Input.GetKeyUp(KeyCode.Keypad8) && startUpFrames == 5 && lowInputTime < 0.6f && !gc.roundFinished) //Fierce Punch
        {
            playerSpeed = 0f;
            startUpFrames -= 0.1f;
            lowFierceP = true;
        }

        //Low Light Punch Function
        if (startUpFrames < 5 && lowLightP)
        {
            standFrame1.SetActive(false);
            lowFrame1.SetActive(true);

            startUpFrames -= Time.deltaTime;

            if (startUpFrames > 4.7f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.3f)
            {
                lowFrame2.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.1f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.9f)
            {
                lowFrame3.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.2f)
            {
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames < 3.2f)
            {
                lowFrame2.SetActive(false);
                lowFrame3.SetActive(false);
                lowFrame4.SetActive(false);
                lowFrame5.SetActive(false);
                lowFrame6.SetActive(false);

                startUpFrames = 5.0f;
                playerSpeed = 3.5f;
                lowInputTime = 1.0f;
                lowLightP = false;

                standFrame1.SetActive(true);
                lowFrame1.SetActive(false);
            }
        }

        //Low Fierce Punch Function
        if (startUpFrames < 5 && lowFierceP)
        {
            standFrame1.SetActive(false);
            lowFrame1.SetActive(true);

            startUpFrames -= Time.deltaTime;

            if (startUpFrames > 4.7f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.3f)
            {
                lowFrame2.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 4.1f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.9f)
            {
                lowFrame3.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.6f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 3.2f)
            {
                lowFrame4.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 2.8f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 2.5f)
            {
                lowFrame5.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames > 2.1f)
            {
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 1.8f)
            {
                lowFrame6.SetActive(true);
                startUpFrames -= Time.deltaTime;
            }

            else if (startUpFrames > 0.8f)
            {
                startUpFrames -= Time.deltaTime;
            }

            if (startUpFrames < 0.8f)
            {
                lowFrame2.SetActive(false);
                lowFrame3.SetActive(false);
                lowFrame4.SetActive(false);
                lowFrame5.SetActive(false);
                lowFrame6.SetActive(false);

                startUpFrames = 5.0f;
                playerSpeed = 3.5f;
                lowInputTime = 1.0f;
                lowFierceP = false;

                standFrame1.SetActive(true);
                lowFrame1.SetActive(false);
            }
        }

        #endregion
    }
}
