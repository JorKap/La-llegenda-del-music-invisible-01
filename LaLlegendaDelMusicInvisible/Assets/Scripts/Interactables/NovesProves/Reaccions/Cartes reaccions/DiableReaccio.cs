using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiableReaccio : Reaccio
{
    public GameObject dadesCartes;
    public bool stateCard;

    protected override void ExecutaReaccio()
    {
        dadesCartes.GetComponent<ElDiableCard>().stateCard = stateCard;
    }
}
