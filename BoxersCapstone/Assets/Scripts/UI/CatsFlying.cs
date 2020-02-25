using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsFlying : MonoBehaviour
{
    public GameObject[] cats = new GameObject[8];

    private LerpColor lerp;

    private bool reverse = false;
    private bool reverseIt = false;
    
    private void Start()
    {
        lerp = GameObject.FindGameObjectWithTag("GameController").GetComponent<LerpColor>();
    }

    // Update is called once per frame
    private void Update()
    {
        #region Cats In Order
        if (lerp.colorIndex == 0 && reverseIt && !reverse) // Reverse
        {
            reverse = true;
        }

        else if (lerp.colorIndex == 0 && !reverseIt && reverse) // Undo Reverse
        {
            reverse = false;
        }

        else if (lerp.colorIndex == 0 && lerp.time < .9f && !reverse)
        {
            cats[0].transform.Translate(Vector2.right * Time.deltaTime * 300);
        }

        else if (lerp.colorIndex == 1 && lerp.time < .9f && !reverse)
        {
            cats[1].transform.Translate(Vector2.left * Time.deltaTime * 300);
        }

        else if (lerp.colorIndex == 2 && lerp.time < .9f && !reverse)
        {
            cats[2].transform.Translate(Vector2.left * Time.deltaTime * 300);
            cats[2].transform.Translate(Vector2.down * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 3 && lerp.time < .9f && !reverse)
        {
            cats[3].transform.Translate(Vector2.right * Time.deltaTime * 300);
            cats[3].transform.Translate(Vector2.down * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 4 && lerp.time < .9f && !reverse)
        {
            cats[4].transform.Translate(Vector2.down * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 5 && lerp.time < .9f && !reverse)
        {
            cats[5].transform.Translate(Vector2.up * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 6 && lerp.time < .9f && !reverse)
        {
            cats[6].transform.Translate(Vector2.left * Time.deltaTime * 300);
            cats[6].transform.Translate(Vector2.up * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 7 && lerp.time < .9f && !reverse)
        {
            cats[7].transform.Translate(Vector2.right * Time.deltaTime * 300);
            cats[7].transform.Translate(Vector2.up * Time.deltaTime * 200);
            reverseIt = true;
        }
        #endregion

        #region Cats In Reverse
        if (lerp.colorIndex == 0 && lerp.time < .9f && reverse)
        {
            cats[0].transform.Translate(Vector2.left * Time.deltaTime * 300);
        }

        else if (lerp.colorIndex == 1 && lerp.time < .9f && reverse)
        {
            cats[1].transform.Translate(Vector2.right * Time.deltaTime * 300);
        }

        else if (lerp.colorIndex == 2 && lerp.time < .9f && reverse)
        {
            cats[2].transform.Translate(Vector2.right * Time.deltaTime * 300);
            cats[2].transform.Translate(Vector2.up * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 3 && lerp.time < .9f && reverse)
        {
            cats[3].transform.Translate(Vector2.left * Time.deltaTime * 300);
            cats[3].transform.Translate(Vector2.up * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 4 && lerp.time < .9f && reverse)
        {
            cats[4].transform.Translate(Vector2.up * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 5 && lerp.time < .9f && reverse)
        {
            cats[5].transform.Translate(Vector2.down * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 6 && lerp.time < .9f && reverse)
        {
            cats[6].transform.Translate(Vector2.right * Time.deltaTime * 300);
            cats[6].transform.Translate(Vector2.down * Time.deltaTime * 200);
        }

        else if (lerp.colorIndex == 7 && lerp.time < .9f && reverse)
        {
            cats[7].transform.Translate(Vector2.left * Time.deltaTime * 300);
            cats[7].transform.Translate(Vector2.down * Time.deltaTime * 200);
            reverseIt = false;
        }
        #endregion
    }
}
