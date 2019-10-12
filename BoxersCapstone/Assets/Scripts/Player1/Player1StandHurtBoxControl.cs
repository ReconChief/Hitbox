using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1StandHurtBoxControl : MonoBehaviour
{
    //Using Variables from other Objects
    private Player1Controls player1;

    #region Standing HurtBox Frames
    public GameObject standHurtBoxFrame1;
    public GameObject standHurtBoxFrame2;
    public GameObject standHurtBoxFrame3;
    public GameObject standHurtBoxFrame4;
    public GameObject standHurtBoxFrame5;
    public GameObject standHurtBoxFrame6;
    #endregion

    void Start()
    {
        player1 = GetComponentInParent<Player1Controls>();
    }

    void Update()
    {
        if (player1.standFrame2.activeSelf)
        {
            standHurtBoxFrame1.SetActive(false);
            standHurtBoxFrame2.SetActive(true);

            if (player1.standFrame3.activeSelf)
            {
                standHurtBoxFrame2.SetActive(false);
                standHurtBoxFrame3.SetActive(true);

                if (player1.standFrame4.activeSelf)
                {
                    standHurtBoxFrame3.SetActive(false);
                    standHurtBoxFrame4.SetActive(true);

                    if (player1.standFrame5.activeSelf)
                    {
                        standHurtBoxFrame4.SetActive(false);
                        standHurtBoxFrame5.SetActive(true);

                        if (player1.standFrame6.activeSelf)
                        {
                            standHurtBoxFrame5.SetActive(false);
                            standHurtBoxFrame6.SetActive(true);
                        }
                    }
                }
            }
        }

        else
        {
            standHurtBoxFrame1.SetActive(true);
            standHurtBoxFrame2.SetActive(false);
            standHurtBoxFrame3.SetActive(false);
            standHurtBoxFrame4.SetActive(false);
            standHurtBoxFrame5.SetActive(false);
            standHurtBoxFrame6.SetActive(false);
        }
    }
}
