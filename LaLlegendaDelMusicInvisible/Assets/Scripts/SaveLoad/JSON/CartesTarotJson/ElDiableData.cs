using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ElDiableData 
{
    public string cardName;
    public bool cardState;

    public ElDiableData(ElDiableCard elDiableCard)
    {
        cardName = elDiableCard.cardName;
        cardState = elDiableCard.stateCard;
    }
}
