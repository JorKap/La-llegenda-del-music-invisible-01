using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteColor : MonoBehaviour
{
    public static event Action<Color, Vector3> ColorPicked = delegate { };
    private Color color;
    private Vector3 colorPosition;

    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<Renderer>().material.GetColor("_BaseColor");
        colorPosition = transform.position;

        switch (name)
        {
            case "Red":
                GameControl.properColors[0] = color;
                break;
            case "Yellow":
                GameControl.properColors[1] = color;
                break;
            case "Green":
                GameControl.properColors[2] = color;
                break;
            case "Blue":
                GameControl.properColors[3] = color;
                break;

        }
    }

    private void OnMouseDown()
    {
        ColorPicked(color, colorPosition);
    }
}
