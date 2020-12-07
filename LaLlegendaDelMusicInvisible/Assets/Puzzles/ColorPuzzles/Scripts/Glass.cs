using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public static event Action GlassColorIsSet = delegate { };
    
    private Renderer rend;
    
    private Color colorToApply;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
       


    }
    private void OnMouseOver()
    {
        
    }
    private void OnMouseDown()
    {
        colorToApply = GameControl.fingerColor;
        rend.material.SetColor("_BaseColor", colorToApply);

        switch (name)
        {
            case "RedGlass":
                if (colorToApply == GameControl.properColors[0])
                    GameControl.redIsRed = true;
                else
                    GameControl.redIsRed = false;
                break;

            case "YellowGlass":
                if (colorToApply == GameControl.properColors[1])
                    GameControl.yellowIsyellow = true;
                else
                    GameControl.yellowIsyellow = false;
                break;

            case "GreenGlass":
                if (colorToApply == GameControl.properColors[2])
                    GameControl.greenIsGreen = true;
                else
                    GameControl.greenIsGreen = false;
                break;

            case "BlueGlass":
                if (colorToApply == GameControl.properColors[3])
                    GameControl.blueIsBlue = true;
                else
                    GameControl.blueIsBlue = false;
                break;

        }
        GlassColorIsSet();
    }
}
