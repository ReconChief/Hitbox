using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2LowHitBoxControl : MonoBehaviour
{
    //Using Variables from other Objects
    private GameObject player2Object;
    private Player2Controls player2;

    //HitBoxes Frames
    public GameObject lowLightPunchHitBox;
    public GameObject lowFiercePunchHitBox;

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
        if (player2.lowLightP)
        {
            if (!valueSet)
            {
                resetPosition = lowLightPunchHitBox.transform.position;
                valueSet = true;
            }

            if (player2.startUpFrames > 3.5 && player2.startUpFrames < 3.9)
            {
                lowLightPunchHitBox.SetActive(true);
                lowLightPunchHitBox.transform.position += new Vector3(0.01f, 0, 0) * Time.deltaTime * 0.01f;
                hurtBox.SetActive(false);
            }

            else
            {
                lowLightPunchHitBox.transform.position = resetPosition;
                lowLightPunchHitBox.SetActive(false);
                hurtBox.SetActive(true);
                valueSet = false;
            }
        }

        else if (player2.lowFierceP)
        {
            if (!valueSet)
            {
                resetPosition = lowFiercePunchHitBox.transform.position;
                valueSet = true;
            }

            if (player2.startUpFrames > 1.5 && player2.startUpFrames < 1.8)
            {
                lowFiercePunchHitBox.SetActive(true);
                lowFiercePunchHitBox.transform.position += new Vector3(0.01f, 0, 0) * Time.deltaTime * 0.01f;
                hurtBox.SetActive(false);
            }

            else
            {
                lowFiercePunchHitBox.transform.position = resetPosition;
                lowFiercePunchHitBox.SetActive(false);
                hurtBox.SetActive(true);
                valueSet = false;
            }
        }
    }
}
