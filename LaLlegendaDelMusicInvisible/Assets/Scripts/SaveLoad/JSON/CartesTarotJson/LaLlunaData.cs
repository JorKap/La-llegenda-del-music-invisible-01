using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LaLlunaData
{ 
    public string cardName;
    public bool cardState;


    public LaLlunaData(LaLlunaCarta laLlunaCarta)
    {
        cardName = laLlunaCarta.cardName;
        cardState = laLlunaCarta.stateCard;
    }
}
