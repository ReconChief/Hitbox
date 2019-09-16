using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2StandHitBoxControl : MonoBehaviour
{
    //Using Variables from other Objects
    private GameObject player2Object;
    private Player2Controls player2;

    //HitBoxes Frames
    public GameObject standLightPunchHitBox;
    public GameObject standFiercePunchHitBox;

    //HurtBox
    public GameObject hurtBox;

    //Reset Hitbox Values
    public Vector3 resetPosition;
    public bool valueSet = false;

    void Start()
    {
        player2Object = GameObject.FindGameObjectWithTag("Player2");
        player2 = player2Object.GetComponent<Player2Controls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player2.standLightP)
        {
            if (!valueSet)
            {
                resetPosition = standLightPunchHitBox.transform.position;
                valueSet = true;
            }

            if (player2.startUpFrames > 3.5 && player2.startUpFrames < 3.9)
            {
                standLightPunchHitBox.SetActive(true);
                standLightPunchHitBox.transform.position += new Vector3 (0.01f, 0, 0) * Time.deltaTime * 0.01f;
                hurtBox.SetActive(false);
            }

            else
            {
                standLightPunchHitBox.transform.position = resetPosition;
                standLightPunchHitBox.SetActive(false);
                hurtBox.SetActive(true);
                valueSet = false;
            }
        }

        else if (player2.standFierceP)
        {
            if (!valueSet)
            {
                resetPosition = standFiercePunchHitBox.transform.position;
                valueSet = true;
            }

            if (player2.startUpFrames > 1.5 && player2.startUpFrames < 1.8)
            {
                standFiercePunchHitBox.SetActive(true);
                standFiercePunchHitBox.transform.position += new Vector3(0.01f, 0, 0) * Time.deltaTime * 0.01f;
                hurtBox.SetActive(false);
            }

            else
            {
                standFiercePunchHitBox.transform.position = resetPosition;
                standFiercePunchHitBox.SetActive(false);
                hurtBox.SetActive(true);
                valueSet = false;
            }
        }
    }
}
