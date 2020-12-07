using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour
{
    public Interactuables[] interactuables;
    

    public void Interactua()
    {
        for (int i = 0; i < interactuables.Length; i++)
        {
           
            if (interactuables[i].gestioCondicions.ComprovaCondicions())
            {
                Debug.Log("pots entrar");
                interactuables[i].reaccionsPosteriors.ActivaReaccions();
            }
            else
            {
                Debug.Log("Has de realitzar una missió");
                interactuables[i].reaccionsPrevies.ActivaReaccions();
            }
        }
        

    }
}
[System.Serializable]
public class Interactuables
{
    public string descripcio;
    public Condicions gestioCondicions;
    public GestioReaccionsPrevies reaccionsPrevies;
    public GestioReaccionsPosteriors reaccionsPosteriors;
}