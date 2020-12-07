using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reaccio : MonoBehaviour
{
    public void Reacciona()
    {
        ExecutaReaccio();
    }

    protected abstract void ExecutaReaccio();
}
