using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PortaPedraVestibul : MonoBehaviour
{
    public PlayableDirector playableDirector;
    //public bool state;
    public StateComponentsScriptable stateComponents;
    public Collider colliderGObj;

    private void Start()
    {

        //playableDirector.enabled = false;
        for (int i = 0; i < stateComponents.stateComponents.Count; i++)
        {
            if (stateComponents.stateComponents[i].nameGobj == this.name)
            {
                playableDirector.enabled = stateComponents.stateComponents[i].state;
                gameObject.SetActive(stateComponents.stateComponents[i].state);
                colliderGObj.enabled = false;
            }
        }

    }
    private void Update()
    {

        if (!playableDirector.isActiveAndEnabled)
        {
            Debug.Log("Playable" + playableDirector.isActiveAndEnabled);

            for (int i = 0; i < stateComponents.stateComponents.Count; i++)
            {
                if (stateComponents.stateComponents[i].nameGobj == gameObject.name)
                {
                    stateComponents.stateComponents[i].state = false;
                    return;
                }
            }

        }
    }

    
}
