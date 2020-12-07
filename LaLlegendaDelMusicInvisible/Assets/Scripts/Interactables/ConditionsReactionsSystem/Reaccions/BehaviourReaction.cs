﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourReaction : Reactions
{
    public Behaviour behaviour;     // The Behaviour to be turned on or off.
    public bool enabledState;       // The state the Behaviour will be in after the Reaction.


    protected override void ImmediateReaction()
    {
        behaviour.enabled = enabledState;
    }
}
