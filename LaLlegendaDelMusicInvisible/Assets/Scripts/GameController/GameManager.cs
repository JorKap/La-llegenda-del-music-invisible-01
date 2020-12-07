using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform portaEntrada;
    

   // public InteractablePlace startingPlace;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
      
    }
    //private static void SaveJsonData(GameManager gameManager)
    //{
      
    //    SaveDataJSON sd = new SaveDataJSON();
    //    //sd.m_score = gameManager.portaEntrada.eulerAngles.y;
    //    gameManager.PopulateSaveData(sd);
    //    string jsonPath = Application.persistentDataPath + "/JsonData.json";

    //    File.WriteAllText(jsonPath, sd.ToJson());

    //}
    //private static void LoadJsonData(GameManager gameManager)
    //{
    //    string jsonPath = Application.persistentDataPath + "/JsonData.json";
    //    if (File.Exists(jsonPath))
    //    {
    //        SaveDataJSON sd = new SaveDataJSON();
    //        string jsonRead = File.ReadAllText(jsonPath);
    //        sd.LoadFromJson(jsonRead);
    //        gameManager.LoadFromSaveData(sd);
            
    //    }
    //    else
    //    {
    //        Debug.LogError("Save file not found in" + jsonPath);
            
    //    }
    //}

    //public void PopulateSaveData(SaveDataJSON saveData)
    //{
    //    saveData.m_score = portaEntrada.eulerAngles.y;
    //}

    //public void LoadFromSaveData(SaveDataJSON saveData)
    //{
    //    float rotY = saveData.m_score;
    //    portaEntrada.eulerAngles = new Vector3(0, rotY, 0);
    //}
}
