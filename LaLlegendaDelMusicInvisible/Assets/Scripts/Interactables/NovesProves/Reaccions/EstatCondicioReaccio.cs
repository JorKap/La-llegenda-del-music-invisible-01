using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstatCondicioReaccio : Reaccio
{
    public string descripcioCondicio;
    public bool estat;
    private Condicio condicio;
    public TotesCondicionsScriptable condicionsScriptable;

    protected override void ExecutaReaccio()
    {
        condicio.estat = estat;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < condicionsScriptable.condicions.Count; i++)
        {
            if (condicionsScriptable.condicions[i].descripcio == descripcioCondicio)
                condicio = condicionsScriptable.condicions[i];
        }
    }

    
}
