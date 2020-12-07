using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaLlunaCarta : MonoBehaviour
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
        SaveCards.SaveLaLluna(this);
    }

    private void OnEnable()
    {
        LaLlunaData lluna = SaveCards.LoadLaLluna();
        cardName = lluna.cardName;
        stateCard = lluna.cardState;
    }
}
