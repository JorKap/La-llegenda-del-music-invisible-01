using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnableReaccio : Reaccio
{
    Collider col;
    public bool colEnable;
    private void Start()
    {
        col = transform.parent.GetComponent<Collider>();
    }
    protected override void ExecutaReaccio()
    {
        col.enabled = colEnable;
    }

    
}
