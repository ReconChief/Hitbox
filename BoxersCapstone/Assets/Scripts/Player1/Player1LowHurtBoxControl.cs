using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1LowHurtBoxControl : MonoBehaviour
{
    //Using Variables from other Objects
    private GameObject player1Object;
    private Player1Controls player1;

    public GameObject normalHurtBox;

    [Header("Light Frames")]
    #region Low Light HurtBox Frames
    public GameObject lightHurtBoxFrame1;
    public GameObject lightHurtBoxFrame2;
    public GameObject lightHurtBoxFrame3;
    #endregion

    #region Low Fierce HurtBox Frames
    public GameObject fierceHurtBoxFrame1;
    public GameObject fierceHurtBoxFrame2;
    public GameObject fierceHurtBoxFrame3;
    public GameObject fierceHurtBoxFrame4;
    public GameObject fierceHurtBoxFrame5;
    public GameObject fierceHurtBoxFrame6;
    #endregion

    void Start()
    {
        player1Object = GameObject.FindGameObjectWithTag("Player1");
        player1 = player1Object.GetComponent<Player1Controls>();
    }
    
    void Update()
    {
        #region LightHurtBoxActivation
        if (player1.lowLightFrame1.activeSelf)
        {
            normalHurtBox.SetActive(false);
            lightHurtBoxFrame1.SetActive(true);
        }

        else if (player1.lowLightFrame2.activeSelf)
        {
            lightHurtBoxFrame1.SetActive(false);
            lightHurtBoxFrame2.SetActive(true);
        }

        else if (player1.lowLightFrame3.activeSelf)
        {
            lightHurtBoxFrame2.SetActive(false);
            lightHurtBoxFrame3.SetActive(true);
        }

        else
        {
            lightHurtBoxFrame1.SetActive(false);
            lightHurtBoxFrame2.SetActive(false);
            lightHurtBoxFrame3.SetActive(false);

            normalHurtBox.SetActive(true);
        }
        #endregion

        #region FierceHurtBoxActivation
        if (player1.lowFierceFrame1.activeSelf)
        {
            normalHurtBox.SetActive(false);
            fierceHurtBoxFrame1.SetActive(true);
        }

        else if (player1.lowFierceFrame2.activeSelf)
        {
            fierceHurtBoxFrame1.SetActive(false);
            fierceHurtBoxFrame2.SetActive(true);
        }

        else if (player1.lowFierceFrame3.activeSelf)
        {
            fierceHurtBoxFrame2.SetActive(false);
            fierceHurtBoxFrame3.SetActive(true);
        }

        else if (player1.lowFierceFrame4.activeSelf)
        {
            fierceHurtBoxFrame3.SetActive(false);
            fierceHurtBoxFrame4.SetActive(true);
        }

        else if (player1.lowFierceFrame5.activeSelf)
        {
            fierceHurtBoxFrame4.SetActive(false);
            fierceHurtBoxFrame5.SetActive(true);
        }

        else if (player1.lowFierceFrame6.activeSelf)
        {
            fierceHurtBoxFrame5.SetActive(false);
            fierceHurtBoxFrame6.SetActive(true);
        }

        else
        {
            fierceHurtBoxFrame1.SetActive(false);
            fierceHurtBoxFrame2.SetActive(false);
            fierceHurtBoxFrame3.SetActive(false);
            fierceHurtBoxFrame4.SetActive(false);
            fierceHurtBoxFrame5.SetActive(false);
            fierceHurtBoxFrame6.SetActive(false);

            normalHurtBox.SetActive(true);
        }
        #endregion
    }
}
