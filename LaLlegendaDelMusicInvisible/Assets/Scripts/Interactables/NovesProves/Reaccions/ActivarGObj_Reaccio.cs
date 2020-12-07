using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarGObj_Reaccio : Reaccio
{
    public GameObject gameObj;      
    public bool activeState;
    protected override void ExecutaReaccio()
    {
        gameObj.SetActive(activeState);
    }

    
}
