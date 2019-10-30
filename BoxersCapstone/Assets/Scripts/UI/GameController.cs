using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game Object Variables")]
    //Using Variables from other Objects
    private Player1Controls player1;
    public GameObject p1StandHitBox;
    public GameObject p1LowHitBox;
    public GameObject player1Body;
    public GameObject player1CrouchBody;

    private Player2Controls player2;
    public GameObject p2StandHitBox;
    public GameObject p2LowHitBox;
    public GameObject player2Body;
    public GameObject player2CrouchBody;

    public GameObject roundText;

    public GameObject p1Boundaries;
    public GameObject p2Boundaries;

    [Header("Timer Variables")]
    //Timers
    public float timer;
    public float roundTimer;

    //UI Text
    public Text timerText;
    public Text numberOfRoundText;

    #region Resetting Hitboxes
    [Header("Reset Variables")]
    private Vector3 p1ResetStandPositions;
    private Vector3 p1ResetLowPositions;
    private Vector3 p2ResetStandPositions;
    private Vector3 p2ResetLowPositions;

    private Vector3 p1ResetBoundaries;
    private Vector3 p2ResetBoundaries;

    [Header("Reset GameObject Variables")]
    public GameObject player1StandLightHitBox;
    public GameObject player1StandFierceHitBox;

    public GameObject player1LowLightHitBox;
    public GameObject player1LowFierceHitBox;

    public GameObject player2StandLightHitBox;
    public GameObject player2StandFierceHitBox;

    public GameObject player2LowLightHitBox;
    public GameObject player2LowFierceHitBox;
    #endregion

    [Header("Round Variables")]
    #region Rounds Variables
    public bool roundFinished = true;
    public int roundNumber = 1;

    //# of Rounds Won per Player
    public int player1Wins = 0;
    public int player2Wins = 0;

    #region Player 1 Rounds Display
    public GameObject player1Round1;
    public GameObject player1Round2;
    public GameObject player1Round3;

    public GameObject player1Round1Won;
    public GameObject player1Round2Won;
    public GameObject player1Round3Won;
    #endregion

    #region Player 2 Rounds Display
    public GameObject player2Round1;
    public GameObject player2Round2;
    public GameObject player2Round3;

    public GameObject player2Round1Won;
    public GameObject player2Round2Won;
    public GameObject player2Round3Won;
    #endregion

    #endregion

    [Header("Sound Effects")]
    public AudioSource hit;

    void Awake()
    {
        if (PlayerPrefs.HasKey("roundNumber"))
        {
            RecoverGameData();
        }

        else
        {
            NewFight();
        }
    }

    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1Controls>();

        p1ResetStandPositions = player1StandLightHitBox.transform.position;
        p1ResetLowPositions = player1LowLightHitBox.transform.position;

        player2 = GameObject.Find("Player2").GetComponent<Player2Controls>();

        p2ResetStandPositions = player2StandLightHitBox.transform.position;
        p2ResetLowPositions = player2LowLightHitBox.transform.position;

        p1ResetBoundaries = p1Boundaries.transform.position;
        p2ResetBoundaries = p2Boundaries.transform.position;

        timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

    void Update()
    {

        if (roundFinished && roundTimer >= 0) //Reset Round (player's position and updated UI Look)
        {
            //Timer to Display Round Number
            roundTimer -= Time.deltaTime;
            roundText.SetActive(true);

            //Display Text
            if (roundTimer >= 2)
            {
                numberOfRoundText.text = "ROUND " + roundNumber.ToString();
            }

            else if (roundTimer >= 0.5)
            {
                numberOfRoundText.text = "READY";
            }

            else if (roundTimer >= 0)
            {
                numberOfRoundText.text = "FIGHT";
            }

            timerText.color = new Color(1, 1, 1, 1);
            timerText.text = timer.ToString("F0");

            //ResetPositions();
        }

        else
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F0");
            roundFinished = false;
            roundText.SetActive(false);
        }

        #region Timer Color Change
        if (timer >= 18 && timer <= 23)
        {
            timerText.color = new Color(1, .8f, .8f, 1);
        }

        else if (timer >= 14 && timer <= 17)
        {
            timerText.color = new Color(1, .4f, .4f, 1);
        }

        else if (timer >= 9 && timer <= 13)
        {
            timerText.color = new Color(1, .3f, .3f, 1);
        }

        else if (timer >= 5 && timer <= 8)
        {
            timerText.color = new Color(1, .2f, .2f, 1);
        }

        else if (timer >= 0 && timer <= 4)
        {
            timerText.color = new Color(1, 0, 0, 1);
        }
        #endregion

        //Player 1 Rounds Display
        switch (player1Wins)
        {
            case 1:
                player1Round1.SetActive(false);
                player1Round2.SetActive(true);
                player1Round3.SetActive(true);

                player1Round1Won.SetActive(true);
                player1Round2Won.SetActive(false);
                player1Round3Won.SetActive(false);
                break;

            case 2:
                player1Round1.SetActive(false);
                player1Round2.SetActive(false);
                player1Round3.SetActive(true);

                player1Round1Won.SetActive(true);
                player1Round2Won.SetActive(true);
                player1Round3Won.SetActive(false);
                break;

            case 3:
                player1Round1.SetActive(false);
                player1Round2.SetActive(false);
                player1Round3.SetActive(false);

                player1Round1Won.SetActive(true);
                player1Round2Won.SetActive(true);
                player1Round3Won.SetActive(true);
                break;

            default:
                player1Round1.SetActive(true);
                player1Round2.SetActive(true);
                player1Round3.SetActive(true);

                player1Round1Won.SetActive(false);
                player1Round2Won.SetActive(false);
                player1Round3Won.SetActive(false);
                break;
        }

        //Player 2 Rounds Display
        switch (player2Wins)
        {
            case 1:
                player2Round1.SetActive(false);
                player2Round2.SetActive(true);
                player2Round3.SetActive(true);

                player2Round1Won.SetActive(true);
                player2Round2Won.SetActive(false);
                player2Round3Won.SetActive(false);
                break;

            case 2:
                player2Round1.SetActive(false);
                player2Round2.SetActive(false);
                player2Round3.SetActive(true);

                player2Round1Won.SetActive(true);
                player2Round2Won.SetActive(true);
                player2Round3Won.SetActive(false);
                break;

            case 3:
                player2Round1.SetActive(false);
                player2Round2.SetActive(false);
                player2Round3.SetActive(false);

                player2Round1Won.SetActive(true);
                player2Round2Won.SetActive(true);
                player2Round3Won.SetActive(true);
                break;

            default:
                player2Round1.SetActive(true);
                player2Round2.SetActive(true);
                player2Round3.SetActive(true);

                player2Round1Won.SetActive(false);
                player2Round2Won.SetActive(false);
                player2Round3Won.SetActive(false);
                break;
        }

        if (timer <= 0)
        {
            TimeoutRound();
        }
        
        if (player1Wins >= 3)
        {
            EraseGameData();
            SceneManager.LoadScene("Player1W");
        }
        
        if (player2Wins >= 3)
        {
            EraseGameData();
            SceneManager.LoadScene("Player2W");
        }
        
        player1CrouchBody.transform.position = player1Body.transform.position + new Vector3 (0,-1,0);
        player2CrouchBody.transform.position = player2Body.transform.position + new Vector3(0, -1, 0);
    }

    public void Player1WinsRound()
    {
        hit.Play();
        roundFinished = true; //Player freezes
        roundNumber++;
        player1Wins++;

        SaveGameData();
        SceneManager.LoadScene("Game");

        //player1Body.transform.position = new Vector2(-3, -1.82f);
        //player2Body.transform.position = new Vector2(3, -1.82f);

        roundTimer = 3;
        timer = 30;
    }

    public void Player2WinsRound()
    {
        hit.Play();
        roundFinished = true; //Player freezes
        roundNumber++;
        player2Wins++;

        SaveGameData();
        SceneManager.LoadScene("Game");

        //player1Body.transform.position = new Vector2(-3, -1.82f);
        //player2Body.transform.position = new Vector2(3, -1.82f);

        roundTimer = 3;
        timer = 30;
    }

    void TimeoutRound()
    {
        roundFinished = true;

        //Whoever is closest to the middle wins the round
        if (player1.distanceFromMid > player2.distanceFromMid)
        {
            Player1WinsRound();
            roundNumber++;
        }

        if (player1.distanceFromMid < player2.distanceFromMid)
        {
            Player2WinsRound();
            roundNumber++;
        }

        SaveGameData();
        SceneManager.LoadScene("Game");

        //player1Body.transform.position = new Vector2(-3, -1.82f);
        //player2Body.transform.position = new Vector2(3, -1.82f);

        roundTimer = 3;
        timer = 30;
    }

    /*
    void ResetPositions()
    {
        //Player 1 Reset Hitboxes
        player1StandLightHitBox.transform.position = p1ResetStandPositions + new Vector3(-0.035f, 0.017f, 0);
        player1StandFierceHitBox.transform.position = p1ResetStandPositions + new Vector3(-0.035f, 0.017f, 0);

        player1LowLightHitBox.transform.position = p1ResetLowPositions + new Vector3(-0.04f, -0.053f, 0);
        player1LowFierceHitBox.transform.position = p1ResetLowPositions + new Vector3(-0.04f, -0.053f, 0);

        //Player 2 Reset Hitboxes
        player2StandLightHitBox.transform.position = p2ResetStandPositions + new Vector3(-0.035f, 0.017f, 0);
        player2StandFierceHitBox.transform.position = p2ResetStandPositions + new Vector3(-0.035f, 0.017f, 0);

        player2LowLightHitBox.transform.position = p2ResetLowPositions + new Vector3 (-0.04f, -0.053f, 0);
        player2LowFierceHitBox.transform.position = p2ResetLowPositions + new Vector3(-0.04f, -0.053f, 0);

        //Reset Boundaries
        p1Boundaries.transform.position = p1ResetBoundaries;
        p2Boundaries.transform.position = p2ResetBoundaries;
    }
    */

    void NewFight()
    {
        if(PlayerPrefs.HasKey("roundNumber"))
        {
            EraseGameData();
        }

        roundNumber = 1;
        player1Wins = 0;
        player2Wins = 0;
    }

    private void SaveGameData()
    {
        PlayerPrefs.SetInt("roundNumber", roundNumber);
        PlayerPrefs.SetInt("player1W", player1Wins);
        PlayerPrefs.SetInt("player2W", player2Wins);
    }

    private void RecoverGameData()
    {
        roundNumber = PlayerPrefs.GetInt("roundNumber");
        player1Wins = PlayerPrefs.GetInt("player1W");
        player2Wins = PlayerPrefs.GetInt("player2W");
    }

    private void EraseGameData()
    {
        PlayerPrefs.DeleteKey("roundNumber");
        PlayerPrefs.DeleteKey("player1W");
        PlayerPrefs.DeleteKey("player2W");
    }
}
