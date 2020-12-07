using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int space = 4;
    public bool isPaused;
   
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;


    }
   

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;

    public List<Item> items = new List<Item>();
    //private void Update()
    //{
    //        if()
    //}

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }
        items.Add(item);
        onItemChangeCallback.Invoke();
        
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        onItemChangeCallback.Invoke();

    }

    
}
