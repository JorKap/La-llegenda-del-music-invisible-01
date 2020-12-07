using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PortaEntrada : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public bool state;
    public StateComponentsScriptable stateComponents;
    public PlayerPrefsPortaEntrada prefsData { get; private set; }
    public Collider colliderGObj;

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

        //if (!playableDirector.isActiveAndEnabled)
        //{
        //    Debug.Log("Playable" + playableDirector.isActiveAndEnabled);

        //    for (int i = 0; i < stateComponents.stateComponents.Count; i++)
        //    {
        //        if (stateComponents.stateComponents[i].nameGobj == gameObject.name)
        //        {
        //            stateComponents.stateComponents[i].state = false;
        //            return;
        //        }
        //    }

        //}
    }

    private void OnEnable()
    {
        prefsData = PlayerPrefsPersistentData.LoadPortaEntrada();
        float rotY = prefsData.rotY;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotY, transform.eulerAngles.z);
    }

    private void OnDisable()
    {
        PlayerPrefsPersistentData.SavePortaEntrada(this);
        if (!playableDirector.isActiveAndEnabled)
        {
            Debug.Log("Playable" + playableDirector.isActiveAndEnabled);

            for (int i = 0; i < stateComponents.stateComponents.Count; i++)
            {
                if (stateComponents.stateComponents[i].nameGobj == gameObject.name)
                {
                    stateComponents.stateComponents[i].state = false;

                }
            }

        }
    }
}
