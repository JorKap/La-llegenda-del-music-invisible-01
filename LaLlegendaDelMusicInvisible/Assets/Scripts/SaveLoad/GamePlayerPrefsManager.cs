using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerPrefsManager : MonoBehaviour
{
   // public Transform portaEntrada;
    const string Y_portaEntradaPosicioKey = "portaEntradaPosicio_Y";
    // Start is called before the first frame update
    void Start()
    {
        LoadPrefs();
    }

    private void OnApplicationQuit()
    {
        SavePrefs();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat(Y_portaEntradaPosicioKey, GameManager.instance.portaEntrada.transform.eulerAngles.y);
    }
    public void LoadPrefs()
    {
        var portaEntradaPosition_Y = PlayerPrefs.GetFloat(Y_portaEntradaPosicioKey, 110f);

        GameManager.instance.portaEntrada.transform.rotation = Quaternion.Euler(GameManager.instance.portaEntrada.transform.eulerAngles.x, portaEntradaPosition_Y, GameManager.instance.portaEntrada.transform.eulerAngles.z);

    }
}
