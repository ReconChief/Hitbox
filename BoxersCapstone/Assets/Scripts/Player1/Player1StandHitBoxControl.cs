using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1StandHitBoxControl : MonoBehaviour
{
    //Using Variables from other Objects
    private GameObject player1Object;
    private Player1Controls player1;

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
        player1Object = GameObject.FindGameObjectWithTag("Player1");
        player1 = player1Object.GetComponent<Player1Controls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.standLightP)
        {
            if (!valueSet)
            {
                resetPosition = standLightPunchHitBox.transform.position;
                valueSet = true;
            }

            if (player1.startUpFrames > 3.5 && player1.startUpFrames < 3.9)
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

        else if (player1.standFierceP)
        {
            if (!valueSet)
            {
                resetPosition = standFiercePunchHitBox.transform.position;
                valueSet = true;
            }

            if (player1.startUpFrames > 1.5 && player1.startUpFrames < 1.8)
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
