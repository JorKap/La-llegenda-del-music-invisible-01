using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPlace : MonoBehaviour
{
    //Posició on es posarà el player
    public Transform interactiveLocation;
   // public DestinationPlace backPlace;
    [HideInInspector]
    public DestinationPlace backPlaceVar;

    DestinationPlace currentPlace;
    //Llista dels nodes accessibles des de la posició actual del player
    public List<DestinationPlace> reachablePlaces = new List<DestinationPlace>();
    //Classe que monitoritza els desplaçaments del player
    [HideInInspector]
    public PlayerManager playerManager;

    [HideInInspector]
    public Collider col;

    Interactable interactable;

    private void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;

    }

    private void Start()
    {
       

    }
    public void ReachablePlaces()
    {
        //Leave existing current node
        if (currentPlace != null)
        {
            currentPlace.Leave();
            
        }


        //set currentNode
        currentPlace = this;
        //GameManager.instance.currentPlace = currentPlace;
        

        SetReachablePlaces(true);


    }

    public void Leave()
    {
        SetReachablePlaces(false);
        

    }

    public void SetReachablePlaces(bool set)
    {
        //turn off all reachable colliders
        foreach (DestinationPlace place in reachablePlaces)
        {
            if (place.col != null)
            {

                place.col.enabled = set;

            }

           

        }
    }
}
