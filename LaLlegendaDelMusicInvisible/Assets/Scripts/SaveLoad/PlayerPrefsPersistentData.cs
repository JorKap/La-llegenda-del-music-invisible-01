using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsPersistentData : MonoBehaviour
{
    public static void SaveData(PlayerManager player)
    {
       
        PlayerPrefs.SetString("name", player.transform.parent.parent.name);
        
    }
   public static PlayerPrefsData LoadData()
    {
      
        string parentName = PlayerPrefs.GetString("name", "StartPosition");

        PlayerPrefsData prefsData = new PlayerPrefsData()
        {
           
            LocationName = parentName
        };

        return prefsData;
    }

    //Porta Entrada
    public static void SavePortaEntrada(PortaEntrada gameObject)
    {
        PlayerPrefs.SetFloat("Y_Rotation_PortaEntrada", gameObject.transform.eulerAngles.y);
    }

    public static PlayerPrefsPortaEntrada LoadPortaEntrada()
    {
        float yRot = PlayerPrefs.GetFloat("Y_Rotation_PortaEntrada", 0);

        PlayerPrefsPortaEntrada prefsData = new PlayerPrefsPortaEntrada()
        {
            rotY = yRot
        };
        return prefsData;
    }

    //Porta1 moble codi

    public static void SavePortaCodi1(PortaCodi1 gameObject)
    {
        PlayerPrefs.SetFloat("PortaCodi1", gameObject.transform.eulerAngles.y);
    }

    public static PlayerPrefsMobleCodiPorta1 LoadPortaCodi1()
    {
        float yRot = PlayerPrefs.GetFloat("PortaCodi1", 0);

        PlayerPrefsMobleCodiPorta1 prefsData = new PlayerPrefsMobleCodiPorta1()
        {
            rotY = yRot
        };
        return prefsData;
    }

    //Porta2 moble codi

    public static void SavePortaCodi2(PortaCodi2 gameObject)
    {
        PlayerPrefs.SetFloat("PortaCodi2", gameObject.transform.eulerAngles.y);
    }

    public static PlayerPrefsMobleCodiPorta2 LoadPortaCodi2()
    {
        float yRot = PlayerPrefs.GetFloat("PortaCodi2", 0);

        PlayerPrefsMobleCodiPorta2 prefsData = new PlayerPrefsMobleCodiPorta2()
        {
            rotY = yRot
        };
        return prefsData;
    }

    //Porta Escala
    public static void SavePortaEscala(PortaEscala gameObject)
    {
        PlayerPrefs.SetFloat("PortaEscala", gameObject.transform.eulerAngles.y);
    }

    public static PlayerPrefsPortaEscala LoadPortaEscala()
    {
        float yRot = PlayerPrefs.GetFloat("PortaEscala", 0);

        PlayerPrefsPortaEscala prefsData = new PlayerPrefsPortaEscala()
        {
            rotY = yRot
        };
        return prefsData;
    }

    //Porta Piano
    public static void SavePortaPiano(PortaPiano gameObject)
    {
        PlayerPrefs.SetFloat("PortaPiano", gameObject.transform.eulerAngles.y);
    }

    public static PlayerPrefsPortaSalaPiano LoadPortaPiano()
    {
        float yRot = PlayerPrefs.GetFloat("PortaPiano", 0);

        PlayerPrefsPortaSalaPiano prefsData = new PlayerPrefsPortaSalaPiano()
        {
            rotY = yRot
        };
        return prefsData;
    }
}
