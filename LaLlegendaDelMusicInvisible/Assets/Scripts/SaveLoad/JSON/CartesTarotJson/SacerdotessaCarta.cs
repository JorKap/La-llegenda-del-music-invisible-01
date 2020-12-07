using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacerdotessaCarta : MonoBehaviour
{
    public Item item;
    public string cardName;
    public bool stateCard;


    // Start is called before the first frame update
    void Start()
    {
        cardName = item.name;
        
    }

   
    private void OnDisable()
    {
        SaveCards.SaveSacerdotessa(this);
    }

    private void OnEnable()
    {
        SacerdotessaData sacerdotessa = SaveCards.LoadSacerdotessa();
        cardName = sacerdotessa.cardName;
        stateCard = sacerdotessa.cardState;
    }
}
