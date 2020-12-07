using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaTempransaCarta : MonoBehaviour
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
        SaveCards.SaveLaTempransa(this);
    }

    private void OnEnable()
    {
        LaTempransaData tempransa = SaveCards.LoadLaTempransa();
        cardName = tempransa.cardName;
        stateCard = tempransa.cardState;
    }
}
