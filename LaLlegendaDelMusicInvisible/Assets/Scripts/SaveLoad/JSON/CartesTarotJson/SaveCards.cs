using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveCards 
{
    public static void SaveSacerdotessa(SacerdotessaCarta carta)
    {
        string jsonPath = Application.persistentDataPath + "/sacerdotessa.json";
        SacerdotessaData data = new SacerdotessaData(carta);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
    }

    public static SacerdotessaData LoadSacerdotessa()
    {
        string jsonPath = Application.persistentDataPath + "/sacerdotessa.json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            SacerdotessaData data = JsonUtility.FromJson<SacerdotessaData>(jsonRead);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }

    public static void SaveEldiable(ElDiableCard carta)
    {
        string jsonPath = Application.persistentDataPath + "/elDiable.json";
        ElDiableData data = new ElDiableData(carta);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
    }

    public static ElDiableData LoadEldiable()
    {
        string jsonPath = Application.persistentDataPath + "/elDiable.json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            ElDiableData data = JsonUtility.FromJson<ElDiableData>(jsonRead);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }

    public static void SaveLaLluna(LaLlunaCarta carta)
    {
        string jsonPath = Application.persistentDataPath + "/laLluna.json";
        LaLlunaData data = new LaLlunaData(carta);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
    }

    public static LaLlunaData LoadLaLluna()
    {
        string jsonPath = Application.persistentDataPath + "/laLluna.json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            LaLlunaData data = JsonUtility.FromJson<LaLlunaData>(jsonRead);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }

    public static void SaveLaTempransa(LaTempransaCarta carta)
    {
        string jsonPath = Application.persistentDataPath + "/tempransa.json";
        LaTempransaData data = new LaTempransaData(carta);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
    }

    public static LaTempransaData LoadLaTempransa()
    {
        string jsonPath = Application.persistentDataPath + "/tempransa.json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            LaTempransaData data = JsonUtility.FromJson<LaTempransaData>(jsonRead);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }
}
