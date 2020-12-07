using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerState : MonoBehaviour
{
    public string playerName;
    public int lives;
    public float health;
    MyClass myObject = new MyClass();
    string json;
    private void Start()
    {
        myObject.cardName = "ElDiable";
        myObject.state = true;
        myObject.level = 5;
    }

    //public string SaveToString()
    //{
    //    return JsonUtility.ToJson(this);
    public static void SaveMyClass(MyClass myClass)
    {
        string jsonPath = Application.persistentDataPath + "/myClass.json";
        string json = JsonUtility.ToJson(myClass);
        File.WriteAllText(jsonPath, json);
        
    }
    public static MyClass loadMyClass()
    {
        string jsonPath = Application.persistentDataPath + "/myClass.json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            MyClass myClass= JsonUtility.FromJson<MyClass>(jsonRead);
            return myClass;
        }
        else
        {
            return null;
        }

    }
    //}
    private void OnDisable()
    {
        //json = JsonUtility.ToJson(myObject , true);
        //Debug.Log("json " + json);
        SaveMyClass(myObject);

    }


    private void OnEnable()
    {
        myObject = loadMyClass();
        //myObject = JsonUtility.FromJson<MyClass>(json);
        Debug.Log("myObject " + myObject.cardName);
    }

}

[System.Serializable]
public class MyClass
{
    public string cardName;
    public bool state;
    public int level;
}