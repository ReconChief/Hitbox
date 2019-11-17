using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2StandHurtBoxControl : MonoBehaviour
{
    //Using Variables from other Objects
    private Player2Controls player2;

    public GameObject normalHurtBox;

    [Header("Light")]
    #region Standing Light HurtBox Frames
    public GameObject lightHurtBoxFrame1;
    public GameObject lightHurtBoxFrame2;
    public GameObject lightHurtBoxFrame3;
    #endregion

    [Header("Fierce")]
    #region Standing Fierce HurtBox Frames
    public GameObject fierceHurtBoxFrame1;
    public GameObject fierceHurtBoxFrame2;
    public GameObject fierceHurtBoxFrame3;
    public GameObject fierceHurtBoxFrame4;
    public GameObject fierceHurtBoxFrame5;
    public GameObject fierceHurtBoxFrame6;
    #endregion

    void Start()
    {
        player2 = GetComponentInParent<Player2Controls>();
    }

    void Update()
    {
        #region LightHurtBoxActivation
        if (player2.standLightFrame1.activeSelf)
        {
            normalHurtBox.SetActive(false);
            lightHurtBoxFrame1.SetActive(true);
        }

        else if (player2.standLightFrame2.activeSelf)
        {
            lightHurtBoxFrame1.SetActive(false);
            lightHurtBoxFrame2.SetActive(true);
        }

        else if (player2.standLightFrame3.activeSelf)
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
        if (player2.standFierceFrame1.activeSelf)
        {
            normalHurtBox.SetActive(false);
            fierceHurtBoxFrame1.SetActive(true);
        }

        else if (player2.standFierceFrame2.activeSelf)
        {
            fierceHurtBoxFrame1.SetActive(false);
            fierceHurtBoxFrame2.SetActive(true);
        }

        else if (player2.standFierceFrame3.activeSelf)
        {
            fierceHurtBoxFrame2.SetActive(false);
            fierceHurtBoxFrame3.SetActive(true);
        }

        else if (player2.standFierceFrame4.activeSelf)
        {
            fierceHurtBoxFrame3.SetActive(false);
            fierceHurtBoxFrame4.SetActive(true);
        }

        else if (player2.standFierceFrame5.activeSelf)
        {
            fierceHurtBoxFrame4.SetActive(false);
            fierceHurtBoxFrame5.SetActive(true);
        }

        else if (player2.standFierceFrame6.activeSelf)
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
