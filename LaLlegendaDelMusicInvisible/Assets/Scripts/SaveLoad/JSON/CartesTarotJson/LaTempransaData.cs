using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LaTempransaData
{
    public string cardName;
    public bool cardState;


    public LaTempransaData(LaTempransaCarta tempransaCarta)
    {
        cardName = tempransaCarta.cardName;
        cardState = tempransaCarta.stateCard;
    }
}
