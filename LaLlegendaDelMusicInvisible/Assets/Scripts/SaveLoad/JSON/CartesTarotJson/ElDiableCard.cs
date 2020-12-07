using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElDiableCard : MonoBehaviour
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
        SaveCards.SaveEldiable(this);
    }

    private void OnEnable()
    {
        ElDiableData elDiable = SaveCards.LoadEldiable();
        cardName = elDiable.cardName;
        stateCard = elDiable.cardState;
    }
}
