using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1LowHitBoxControl : MonoBehaviour
{
    //Using Variables from other Objects
    private GameObject player1Object;
    private Player1Controls player1;

    //HitBoxes Frames
    public GameObject lowLightPunchHitBox;
    public GameObject lowFiercePunchHitBox;

    //HurtBox
    public GameObject hurtBox;

    //Reset Hitboxes
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
        if (player1.lowLightP)
        {
            if (!valueSet)
            {
                resetPosition = lowLightPunchHitBox.transform.position;
                valueSet = true;
            }

            if (player1.startUpFrames > 4.4 && player1.startUpFrames < 4.5)
            {
                lowLightPunchHitBox.SetActive(true);
                lowLightPunchHitBox.transform.position += new Vector3(0.01f, 0, 0) * Time.deltaTime;
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

        else if (player1.lowFierceP)
        {
            if (!valueSet)
            {
                resetPosition = lowFiercePunchHitBox.transform.position;
                valueSet = true;
            }

            if (player1.startUpFrames > 3.3 && player1.startUpFrames < 3.7)
            {
                lowFiercePunchHitBox.SetActive(true);
                lowFiercePunchHitBox.transform.position += new Vector3(0.01f, 0, 0) * Time.deltaTime;
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
