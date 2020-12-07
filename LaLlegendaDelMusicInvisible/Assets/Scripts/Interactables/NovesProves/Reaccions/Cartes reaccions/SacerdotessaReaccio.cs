using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacerdotessaReaccio : Reaccio
{
    public GameObject dadesCartes;
    public bool stateCard;

    protected override void ExecutaReaccio()
    {
        dadesCartes.GetComponent<SacerdotessaCarta>().stateCard = stateCard;
    }
           
}
