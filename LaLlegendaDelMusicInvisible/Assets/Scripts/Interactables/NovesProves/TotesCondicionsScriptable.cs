using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TotesCondicions", menuName = "TotesCondicions")]
public class TotesCondicionsScriptable : ScriptableObject
{
   
    public List<Condicio> condicions = new List<Condicio>();

    public bool ComprovaCondicioBaseDades(Condicio condicio)
    {
        Condicio condicioSeleccionada = null;

        for (int i = 0; i < condicions.Count; i++)
        {
            if(condicions[i].descripcio == condicio.descripcio)
            {
                condicioSeleccionada = condicions[i];
            }

        }
        if (condicioSeleccionada == null)
            return false;

        return condicioSeleccionada.estat == condicio.estat;

    }
}
