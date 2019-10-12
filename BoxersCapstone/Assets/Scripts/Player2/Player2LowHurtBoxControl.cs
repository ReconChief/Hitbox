using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2LowHurtBoxControl : MonoBehaviour
{
    //Using Variables from other Objects
    private GameObject player2Object;
    private Player2Controls player2;

    #region Low HurtBox Frames
    public GameObject lowHurtBoxFrame1;
    public GameObject lowHurtBoxFrame2;
    public GameObject lowHurtBoxFrame3;
    public GameObject lowHurtBoxFrame4;
    public GameObject lowHurtBoxFrame5;
    public GameObject lowHurtBoxFrame6;
    #endregion

    void Start()
    {
        player2 = GetComponentInParent<Player2Controls>();
    }

    void Update()
    {
        if (player2.lowFrame2.activeSelf)
        {
            lowHurtBoxFrame1.SetActive(false);
            lowHurtBoxFrame2.SetActive(true);

            if (player2.lowFrame3.activeSelf)
            {
                lowHurtBoxFrame2.SetActive(false);
                lowHurtBoxFrame3.SetActive(true);

                if (player2.lowFrame4.activeSelf)
                {
                    lowHurtBoxFrame3.SetActive(false);
                    lowHurtBoxFrame4.SetActive(true);

                    if (player2.lowFrame5.activeSelf)
                    {
                        lowHurtBoxFrame4.SetActive(false);
                        lowHurtBoxFrame5.SetActive(true);

                        if (player2.lowFrame6.activeSelf)
                        {
                            lowHurtBoxFrame5.SetActive(false);
                            lowHurtBoxFrame6.SetActive(true);
                        }
                    }
                }
            }
        }

        else
        {
            lowHurtBoxFrame1.SetActive(true);
            lowHurtBoxFrame2.SetActive(false);
            lowHurtBoxFrame3.SetActive(false);
            lowHurtBoxFrame4.SetActive(false);
            lowHurtBoxFrame5.SetActive(false);
            lowHurtBoxFrame6.SetActive(false);
        }
    }
}
