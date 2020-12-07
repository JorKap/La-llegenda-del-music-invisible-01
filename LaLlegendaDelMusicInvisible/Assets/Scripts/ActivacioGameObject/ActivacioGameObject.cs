using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacioGameObject : MonoBehaviour
{
    public GameObject gObj;
    public TimelineReaccio timelineReaccio;
    private void OnMouseDown()
    {
        timelineReaccio.Reacciona();
        StartCoroutine(Espera());
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(1);
        gObj.SetActive(false);
    }
}
