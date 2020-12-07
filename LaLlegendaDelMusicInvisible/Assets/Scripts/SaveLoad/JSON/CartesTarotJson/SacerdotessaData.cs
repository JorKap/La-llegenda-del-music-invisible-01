using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SacerdotessaData 
{
    public string cardName;
    public bool cardState;
    

    public SacerdotessaData(SacerdotessaCarta sacerdotessaCarta)
    {
        cardName = sacerdotessaCarta.cardName;
        cardState = sacerdotessaCarta.stateCard;
    }

    
}
