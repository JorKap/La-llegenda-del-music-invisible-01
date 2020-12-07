using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestioReaccionsPrevies : MonoBehaviour
{
    public Reaccio[] reaccions;

    public void ActivaReaccions()
    {
        for (int i = 0; i < reaccions.Length; i++)
        {
            reaccions[i].Reacciona();
        }
    }
}
