using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DisablePlayableDirectorReaccio : Reaccio
{
    public PlayableDirector playableDirector;
    
    protected override void ExecutaReaccio()
    {
        StartCoroutine(DisablePlayableDirector());
    }

    IEnumerator DisablePlayableDirector()
    {
        yield return new WaitForSeconds(2);
        playableDirector.enabled = false;
    }

    
}
