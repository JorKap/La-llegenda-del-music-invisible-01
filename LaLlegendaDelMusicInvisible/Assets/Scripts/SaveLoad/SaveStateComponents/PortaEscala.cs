using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PortaEscala : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public StateComponentsScriptable stateComponents;
    public PlayerPrefsPortaEscala prefsData { get; private set; }

    private void Start()
    {
        //playableDirector.enabled = false;
        for (int i = 0; i < stateComponents.stateComponents.Count; i++)
        {
            if (stateComponents.stateComponents[i].nameGobj == gameObject.name)
            {
                playableDirector.enabled = stateComponents.stateComponents[i].state;
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

    private void OnEnable()
    {
        prefsData = PlayerPrefsPersistentData.LoadPortaEscala();
        float rotY = prefsData.rotY;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotY, transform.eulerAngles.z);
    }

    private void OnDisable()
    {
        PlayerPrefsPersistentData.SavePortaEscala(this);
    }
}
