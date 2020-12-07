﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlunaReaccio : Reaccio
{
    public GameObject dadesCartes;
    public bool stateCard;

    protected override void ExecutaReaccio()
    {
        dadesCartes.GetComponent<LaLlunaCarta>().stateCard = stateCard;
    }


}