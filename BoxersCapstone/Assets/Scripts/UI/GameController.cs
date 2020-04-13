using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [Header("Game Object Variables")]
    //Using Variables from other Objects
    #region Player 1 And 2 Objects
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
    #endregion

    public StageSelection stageSelected;
    public CatSelection catSelected;

    public GameObject roundText;
    public GameObject winnerText;

    public GameObject p1Boundaries;
    public GameObject p2Boundaries;

    public bool paused = false;

    #region Pause Screen
    [Header("Screen")]
    public GameObject pauseScreen;
    public GameObject controlScreen;
    public GameObject optionsScreen;
    public GameObject keyboardScreen;
    public GameObject controllerScreen;

    public GameObject resumeButton;
    public GameObject controlsButton;
    public GameObject returnKeyButton;
    public GameObject returnControllerButton;
    #endregion

    [Header("Timer Variables")]
    //Timers
    public float timer;
    public float roundTimer;
    public float endTimer;

    //UI Text
    public Text timerText;
    public Text numberOfRoundText;
    public Text winner;

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
    public bool p1Win = false;
    public bool p2Win = false;
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
    public AudioSource p1HappyCat;
    public AudioSource p2HappyCat;

    #region BGM
    [Header("Soundtracks")]
    public AudioSource parkTheme;
    public AudioSource dojoTheme;
    public AudioSource catClubTheme;
    public AudioSource soccerFieldTheme;
    public AudioSource intenseParkTheme;
    public AudioSource intenseDojoTheme;
    public AudioSource intenseCatClubTheme;
    public AudioSource intenseSoccerFieldTheme;
    #endregion


    [Header("HitStun Frames")]
    public GameObject p1Stand;
    public GameObject p2Stand;
    public GameObject p1hitStunFrame1;
    public GameObject p1hitStunFrame2;
    public GameObject p2hitStunFrame1;
    public GameObject p2hitStunFrame2;

    #region Claw Effects
    public GameObject[] p1StandShortClawEffects = new GameObject[8];
    public GameObject[] p1StandLongClawEffects = new GameObject[8];
    public GameObject[] p1LowShortClawEffects = new GameObject[8];
    public GameObject[] p1LowLongClawEffects = new GameObject[8];

    public GameObject[] p2StandShortClawEffects = new GameObject[8];
    public GameObject[] p2StandLongClawEffects = new GameObject[8];
    public GameObject[] p2LowShortClawEffects = new GameObject[8];
    public GameObject[] p2LowLongClawEffects = new GameObject[8];
    #endregion

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
        p1ResetStandPositions = player1StandLightHitBox.transform.position;
        p1ResetLowPositions = player1LowLightHitBox.transform.position;

        p2ResetStandPositions = player2StandLightHitBox.transform.position;
        p2ResetLowPositions = player2LowLightHitBox.transform.position;

        p1ResetBoundaries = p1Boundaries.transform.position;
        p2ResetBoundaries = p2Boundaries.transform.position;
       
        stageSelected = this.GetComponent<StageSelection>();
        catSelected = this.GetComponent<CatSelection>();

        timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

    void Update()
    {
        if (!paused)
        {
            if (p1Win || p2Win)
            {
                if (p1Win)
                {
                    p2Stand.SetActive(false);

                    if (endTimer > 4)
                    {
                        p2hitStunFrame1.SetActive(true);
                    }

                    else if (endTimer > 2)
                    {
                        p2hitStunFrame2.SetActive(true);
                    }

                    else if (endTimer <= 0)
                    {
                        SceneManager.LoadScene("Game");
                    }

                    endTimer -= Time.deltaTime;
                }

                else if (p2Win)
                {
                    p1Stand.SetActive(false);

                    if (endTimer > 4)
                    {
                        p1hitStunFrame1.SetActive(true);
                    }

                    else if (endTimer > 2)
                    {
                        p1hitStunFrame2.SetActive(true);
                    }

                    else if (endTimer <= 0)
                    {
                        SceneManager.LoadScene("Game");
                    }

                    endTimer -= Time.deltaTime;
                }
            }

            else if (roundFinished && roundTimer >= 0) //Reset Round (player's position and updated UI Look)
            {
                //Timer to Display Round Number
                roundTimer -= Time.deltaTime;
                roundText.SetActive(true);

                //Display Text
                if (roundTimer >= 2)
                {

                    numberOfRoundText.text = "ROUND " + roundNumber.ToString();
                    if (roundTimer == 2.1)
                    {
                        p1HappyCat.Play();
                    }
                }

                else if (roundTimer >= 0.5)
                {
                    player1 = GameObject.Find("Player1CatFighter").GetComponent<Player1Controls>();
                    player2 = GameObject.Find("Player2CatFighter").GetComponent<Player2Controls>();

                    numberOfRoundText.text = "READY";
                    if (roundTimer == 0.51)
                    {
                        p2HappyCat.Play();
                    }
                }

                else if (roundTimer >= 0)
                {
                    numberOfRoundText.text = "FIGHT";
                    if (roundTimer == 0.1)
                    {
                        p1HappyCat.Play();
                        p2HappyCat.Play();
                    }
                }

                timerText.color = new Color(1, 1, 1, 1);
                timerText.text = timer.ToString("F0");
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
                timerText.color = new Color(1, .6f, .6f, 1);
            }

            else if (timer >= 9 && timer <= 13)
            {
                timerText.color = new Color(1, .4f, .4f, 1);
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

            else if (player1Wins >= 3)
            {
                EraseGameData();
                SceneManager.LoadScene("Player1W");
            }

            else if (player2Wins >= 3)
            {
                EraseGameData();
                SceneManager.LoadScene("Player2W");
            }

            #region SongPlaying
            if (stageSelected.stages[0].activeSelf)
            {
                if (timer > 15 && !parkTheme.isPlaying)
                {
                    parkTheme.Play();
                }

                else if (timer < 15 && !intenseParkTheme.isPlaying)
                {
                    parkTheme.Stop();
                    intenseParkTheme.Play();
                }
            }

            if (stageSelected.stages[1].activeSelf)
            {
                if (timer > 15 && !dojoTheme.isPlaying)
                {
                    dojoTheme.Play();
                }

                else if (timer < 15 && !intenseDojoTheme.isPlaying)
                {
                    dojoTheme.Stop();
                    intenseDojoTheme.Play();
                }
            }

            if (stageSelected.stages[2].activeSelf)
            {
                if (timer > 15 && !catClubTheme.isPlaying)
                {
                    catClubTheme.Play();
                }

                else if (timer < 15 && !intenseCatClubTheme.isPlaying)
                {
                    catClubTheme.Stop();
                    intenseCatClubTheme.Play();
                }
            }

            if (stageSelected.stages[3].activeSelf)
            {
                if (timer > 15 && !soccerFieldTheme.isPlaying)
                {
                    soccerFieldTheme.Play();
                }

                else if (timer < 15 && !intenseSoccerFieldTheme.isPlaying)
                {
                    soccerFieldTheme.Stop();
                    intenseSoccerFieldTheme.Play();
                }
            }
            #endregion

            if (Input.GetButtonDown("StartButton"))
            {
                paused = true;
                Time.timeScale = 0f;
            }
        }

        else
        {
            if (!controlScreen.activeSelf)
            {
                pauseScreen.SetActive(true);

                if (Input.GetButtonDown("StartButton"))
                {
                    Time.timeScale = 1f;
                    pauseScreen.SetActive(false);
                    controlScreen.SetActive(false);
                    keyboardScreen.SetActive(false);
                    controllerScreen.SetActive(false);
                    paused = false;
                }
            }
        }
    }

    public void Player1WinsRound()
    {        
        #region CatClawEffect
        if (catSelected.player1Cats[0])
        {
            if (player1.startUpFrames > 4.3f && player1.standLightP)
            {
                p1StandShortClawEffects[0].SetActive(true);
            }
            
            else if (player1.startUpFrames > 3.2f && player1.standFierceP)
            {
                p1StandLongClawEffects[0].SetActive(true);
            }

            else if (player1.startUpFrames > 4.3f && player1.lowLightP)
            {
                p1LowShortClawEffects[0].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.lowFierceP)
            {
                p1LowLongClawEffects[0].SetActive(true);
            }
        }

        if (catSelected.player1Cats[1])
        {
            if (player1.startUpFrames > 4.3f && player1.standLightP)
            {
                p1StandShortClawEffects[1].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.standFierceP)
            {
                p1StandLongClawEffects[1].SetActive(true);
            }

            else if (player1.startUpFrames > 4.3f && player1.lowLightP)
            {
                p1LowShortClawEffects[1].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.lowFierceP)
            {
                p1LowLongClawEffects[1].SetActive(true);
            }
        }

        if (catSelected.player1Cats[2])
        {
            if (player1.startUpFrames > 4.3f && player1.standLightP)
            {
                p1StandShortClawEffects[2].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.standFierceP)
            {
                p1StandLongClawEffects[2].SetActive(true);
            }

            else if (player1.startUpFrames > 4.3f && player1.lowLightP)
            {
                p1LowShortClawEffects[2].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.lowFierceP)
            {
                p1LowLongClawEffects[2].SetActive(true);
            }
        }

        if (catSelected.player1Cats[3])
        {
            if (player1.startUpFrames > 4.3f && player1.standLightP)
            {
                p1StandShortClawEffects[3].SetActive(true);
            }


            else if (player1.startUpFrames > 3.2f && player1.standFierceP)
            {
                p1StandLongClawEffects[3].SetActive(true);
            }

            else if (player1.startUpFrames > 4.3f && player1.lowLightP)
            {
                p1LowShortClawEffects[3].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.lowFierceP)
            {
                p1LowLongClawEffects[3].SetActive(true);
            }
        }

        if (catSelected.player1Cats[4])
        {
            if (player1.startUpFrames > 4.3f && player1.standLightP)
            {
                p1StandShortClawEffects[4].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.standFierceP)
            {
                p1StandLongClawEffects[4].SetActive(true);
            }

            else if (player1.startUpFrames > 4.3f && player1.lowLightP)
            {
                p1LowShortClawEffects[4].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.lowFierceP)
            {
                p1LowLongClawEffects[4].SetActive(true);
            }
        }

        if (catSelected.player1Cats[5])
        {
            if (player1.startUpFrames > 4.3f && player1.standLightP)
            {
                p1StandShortClawEffects[5].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.standFierceP)
            {
                p1StandLongClawEffects[5].SetActive(true);
            }

            else if (player1.startUpFrames > 4.3f && player1.lowLightP)
            {
                p1LowShortClawEffects[5].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.lowFierceP)
            {
                p1LowLongClawEffects[5].SetActive(true);
            }
        }

        if (catSelected.player1Cats[6])
        {
            if (player1.startUpFrames > 4.3f && player1.standLightP)
            {
                p1StandShortClawEffects[6].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.standFierceP)
            {
                p1StandLongClawEffects[6].SetActive(true);
            }

            else if (player1.startUpFrames > 4.3f && player1.lowLightP)
            {
                p1LowShortClawEffects[6].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.lowFierceP)
            {
                p1LowLongClawEffects[6].SetActive(true);
            }
        }

        if (catSelected.player1Cats[7])
        {
            if (player1.startUpFrames > 4.3f && player1.standLightP)
            {
                p1StandShortClawEffects[7].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.standFierceP)
            {
                p1StandLongClawEffects[7].SetActive(true);
            }

            else if (player1.startUpFrames > 4.3f && player1.lowLightP)
            {
                p1LowShortClawEffects[7].SetActive(true);
            }

            else if (player1.startUpFrames > 3.2f && player1.lowFierceP)
            {
                p1LowLongClawEffects[7].SetActive(true);
            }
        }
        #endregion

        winnerText.SetActive(true);

        winner.text = "PLAYER 1 WINS ";

        hit.Play();
        roundFinished = true; //Player freezes
        p1Win = true; //Player freezes
        roundNumber++;
        player1Wins++;

        endTimer = 5.0f;

        SaveGameData();
    }

    public void Player2WinsRound()
    {
        #region CatClawEffect
        if (catSelected.player2Cats[0])
        {
            if (player2.startUpFrames > 4.3f && player2.standLightP)
            {
                p2StandShortClawEffects[0].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.standFierceP)
            {
                p2StandLongClawEffects[0].SetActive(true);
            }

            else if (player2.startUpFrames > 4.3f && player2.lowLightP)
            {
                p2LowShortClawEffects[0].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.lowFierceP)
            {
                p2LowLongClawEffects[0].SetActive(true);
            }
        }

        if (catSelected.player2Cats[1])
        {
            if (player2.startUpFrames > 4.3f && player2.standLightP)
            {
                p2StandShortClawEffects[1].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.standFierceP)
            {
                p2StandLongClawEffects[1].SetActive(true);
            }

            else if (player2.startUpFrames > 4.3f && player2.lowLightP)
            {
                p2LowShortClawEffects[1].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.lowFierceP)
            {
                p2LowLongClawEffects[1].SetActive(true);
            }
        }

        if (catSelected.player2Cats[2])
        {
            if (player2.startUpFrames > 4.3f && player2.standLightP)
            {
                p2StandShortClawEffects[2].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.standFierceP)
            {
                p2StandLongClawEffects[2].SetActive(true);
            }

            else if (player2.startUpFrames > 4.3f && player2.lowLightP)
            {
                p2LowShortClawEffects[2].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.lowFierceP)
            {
                p2LowLongClawEffects[2].SetActive(true);
            }
        }

        if (catSelected.player2Cats[3])
        {
            if (player2.startUpFrames > 4.3f && player2.standLightP)
            {
                p2StandShortClawEffects[3].SetActive(true);
            }


            else if (player2.startUpFrames > 3.2f && player2.standFierceP)
            {
                p2StandLongClawEffects[3].SetActive(true);
            }

            else if (player2.startUpFrames > 4.3f && player2.lowLightP)
            {
                p2LowShortClawEffects[3].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.lowFierceP)
            {
                p2LowLongClawEffects[3].SetActive(true);
            }
        }

        if (catSelected.player2Cats[4])
        {
            if (player2.startUpFrames > 4.3f && player2.standLightP)
            {
                p2StandShortClawEffects[4].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.standFierceP)
            {
                p2StandLongClawEffects[4].SetActive(true);
            }

            else if (player2.startUpFrames > 4.3f && player2.lowLightP)
            {
                p2LowShortClawEffects[4].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.lowFierceP)
            {
                p2LowLongClawEffects[4].SetActive(true);
            }
        }

        if (catSelected.player2Cats[5])
        {
            if (player2.startUpFrames > 4.3f && player2.standLightP)
            {
                p2StandShortClawEffects[5].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.standFierceP)
            {
                p2StandLongClawEffects[5].SetActive(true);
            }

            else if (player2.startUpFrames > 4.3f && player2.lowLightP)
            {
                p2LowShortClawEffects[5].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.lowFierceP)
            {
                p2LowLongClawEffects[5].SetActive(true);
            }
        }

        if (catSelected.player2Cats[6])
        {
            if (player2.startUpFrames > 4.3f && player2.standLightP)
            {
                p2StandShortClawEffects[6].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.standFierceP)
            {
                p2StandLongClawEffects[6].SetActive(true);
            }

            else if (player2.startUpFrames > 4.3f && player2.lowLightP)
            {
                p2LowShortClawEffects[6].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.lowFierceP)
            {
                p2LowLongClawEffects[6].SetActive(true);
            }
        }

        if (catSelected.player2Cats[7])
        {
            if (player2.startUpFrames > 4.3f && player2.standLightP)
            {
                p2StandShortClawEffects[7].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.standFierceP)
            {
                p2StandLongClawEffects[7].SetActive(true);
            }

            else if (player2.startUpFrames > 4.3f && player2.lowLightP)
            {
                p2LowShortClawEffects[7].SetActive(true);
            }

            else if (player2.startUpFrames > 3.2f && player2.lowFierceP)
            {
                p2LowLongClawEffects[7].SetActive(true);
            }
        }
        #endregion

        winnerText.SetActive(true);

        winner.text = "PLAYER 2 WINS ";

        hit.Play();
        roundFinished = true; //Player freezes
        p2Win = true; //Player freezes
        roundNumber++;
        player2Wins++;

        endTimer = 5.0f;

        SaveGameData();
    }

    private void TimeoutRound()
    {
        roundFinished = true;

        //Whoever is closest to the middle wins the round
        if (player1.distanceFromMid > player2.distanceFromMid)
        {
            Player1WinsRound();
        }

        else if (player1.distanceFromMid < player2.distanceFromMid)
        {
            Player2WinsRound();
        }

        SaveGameData();
        SceneManager.LoadScene("Game");
    }

    private void NewFight()
    {
        if(PlayerPrefs.HasKey("roundNumber"))
        {
            EraseGameData();
        }

        roundNumber = 1;
        player1Wins = 0;
        player2Wins = 0;
    }

    public void QuitFight()
    {
        SceneManager.LoadScene("TitleScreen");
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

    public void returnToGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        paused = false;
    }

    public void returnToPause()
    {
        pauseScreen.SetActive(true);
        controlScreen.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(resumeButton, null);
    }

    public void returnToControls()
    {
        optionsScreen.SetActive(true);
        keyboardScreen.SetActive(false);
        controllerScreen.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(controlsButton, null);
    }

    public void Controls()
    {
        pauseScreen.SetActive(false);
        controlScreen.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(controlsButton, null);
    }

    public void keyboardControls()
    {
        optionsScreen.SetActive(false);
        keyboardScreen.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(returnKeyButton, null);        
    }

    public void controllerControls()
    {
        optionsScreen.SetActive(false);
        controllerScreen.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(returnControllerButton, null);
    }
}
