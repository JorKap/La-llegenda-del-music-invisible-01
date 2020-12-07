using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpReaccio : Reaccio
{
    public Item item;
    private Inventory inventory;

    protected override void ExecutaReaccio()
    {
        Inventory.instance.Add(item);
        Debug.Log("item " + item.name);
    }

   
}
