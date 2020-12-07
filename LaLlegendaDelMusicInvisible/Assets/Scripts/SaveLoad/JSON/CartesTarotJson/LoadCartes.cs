using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCartes : MonoBehaviour
{
    public static LoadCartes instance;

    private void Awake()
    {
        instance = this;
    }
    public List<Item> itemsToDisplay = new List<Item>();
    public List<CartesList> cartesList = new List<CartesList>();

    // Start is called before the first frame update
    void Start()
    {
        SacerdotessaData sacerdotessa = SaveCards.LoadSacerdotessa();
        ElDiableData elDiable = SaveCards.LoadEldiable();
        LaLlunaData laLluna = SaveCards.LoadLaLluna();
        LaTempransaData laTempransa = SaveCards.LoadLaTempransa();
        
        CartesList sacerd = new CartesList();
        sacerd.cardName = sacerdotessa.cardName;
        sacerd.cardState = sacerdotessa.cardState;

        CartesList diable = new CartesList();
        diable.cardName = elDiable.cardName;
        diable.cardState = elDiable.cardState;

        CartesList lluna = new CartesList();
        lluna.cardName = laLluna.cardName;
        lluna.cardState = laLluna.cardState;

        CartesList tempransa = new CartesList();
        tempransa.cardName = laTempransa.cardName;
        tempransa.cardState = laTempransa.cardState;

        cartesList.Add(diable);
        cartesList.Add(sacerd);
        cartesList.Add(lluna);
        cartesList.Add(tempransa);



    }
   

    // Update is called once per frame
    void Update()
    {
        DisplayCards();

    }

    void DisplayCards()
    {
        for (int i = 0; i < cartesList.Count; i++)
        {
            for (int j = 0; j < itemsToDisplay.Count; j++)
            {
                if (cartesList[i].cardState == true)
                {
                    if (cartesList[i].cardName == itemsToDisplay[j].name)
                    {

                        Inventory.instance.Add(itemsToDisplay[j]);
                        cartesList[i].cardState = false;


                    }
                }

            }
        }
    }
}

[System.Serializable]
public class CartesList
{
    public string cardName;
    public bool cardState;
    
}
