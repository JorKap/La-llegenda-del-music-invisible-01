using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddReachablePlaceReaction : Reactions
{
    public DestinationPlace place;

    DestinationPlace currentPlace;

    private void Start()
    {
        currentPlace = transform.parent.parent.GetComponent<DestinationPlace>();
    }
    protected override void ImmediateReaction()
    {
        currentPlace.reachablePlaces.Add(place);
        currentPlace.SetReachablePlaces(true);
    }
}
