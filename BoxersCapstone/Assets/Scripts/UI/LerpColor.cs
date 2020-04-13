using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpColor : MonoBehaviour
{
    public RawImage bg;

    [Range(0f, 1f)] public float lerpTime;

    public Color[] differentColors = new Color[8];

    public int colorIndex = 0;

    public float time = 0f;

    void Update()
    {
        bg.color = Color.Lerp(bg.color, differentColors[colorIndex], lerpTime * Time.deltaTime);

        time = Mathf.Lerp(time, 1f, lerpTime * Time.deltaTime);

        if (time > .9f)
        {
            time = 0f;

            lerpTime = .7f;

            colorIndex++;

            colorIndex = (colorIndex >= differentColors.Length) ? 0 : colorIndex;
        }
    }
}
