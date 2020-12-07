using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condicions : MonoBehaviour
{
    public Condicio[] condicions;
    private TotesCondicionsScriptable condicionsScriptable;
    private void Awake()
    {
        condicionsScriptable = Resources.Load<TotesCondicionsScriptable>("TotesCondicions");
    }

    public bool ComprovaCondicions()
    {
        for (int i = 0; i < condicions.Length; i++)
        {
            if (!condicionsScriptable.ComprovaCondicioBaseDades(condicions[i]))
                return false;

        }

        return true;
    }
}
