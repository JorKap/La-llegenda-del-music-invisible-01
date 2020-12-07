using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempransaReaccio : Reaccio
{
    public GameObject dadesCartes;
    public bool stateCard;

    protected override void ExecutaReaccio()
    {
        dadesCartes.GetComponent<LaTempransaCarta>().stateCard = stateCard;
    }
}
