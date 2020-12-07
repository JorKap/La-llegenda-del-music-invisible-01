using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StateComponent" , menuName = "StateComponent")]
public class StateComponentsScriptable : ScriptableObject
{
    public List<StateComponents> stateComponents = new List<StateComponents>();
}
