using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataJSON
{
   
}

public interface ISaveable
{
    void PopulateSaveData(SaveDataJSON saveData);
    void LoadFromSaveData(SaveDataJSON saveData);
}
