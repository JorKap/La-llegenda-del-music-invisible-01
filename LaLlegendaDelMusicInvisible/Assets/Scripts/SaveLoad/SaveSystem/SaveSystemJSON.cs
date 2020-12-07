using UnityEngine;
using System.IO;

public static class SaveSystemJSON
{
    public static void SavePlayerData(PlayerManager playerManager)
    {
        string jsonPath = Application.persistentDataPath + "/PlayerData.json";
        PlayerData data = new PlayerData(playerManager);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
        //Debug.Log("PlayerData " + json);
    }

    public static PlayerData LoadPlayerData()
    {
        string jsonPath = Application.persistentDataPath + "/PlayerData.json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonRead);
            return playerData;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }

    public static void SaveGameObjectsData(UnlockedGameObjects unlockedGameObjects)
    {
        string jsonPath = Application.persistentDataPath + "/GameObjectsData.json";
        GameObjectsData data = new GameObjectsData(unlockedGameObjects);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
        //Debug.Log("GameObjectsData " + json);
    }

    public static GameObjectsData LoadGameObjectsData()
    {
        string jsonPath = Application.persistentDataPath + "/GameObjectsData.json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            GameObjectsData gameObjectsData = JsonUtility.FromJson<GameObjectsData>(jsonRead);
            //Debug.Log("gameObjectsData return " + gameObjectsData.state[0]);
            return gameObjectsData;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }

    public static void SaveInventoryData(Inventory inventory)
    {
        string jsonPath = Application.persistentDataPath + "/InventoryData.json";
        InventoryData data = new InventoryData(inventory);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);

    }

    public static InventoryData LoadInventoryData()
    {
        string jsonPath = Application.persistentDataPath + "/InventoryData.json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(jsonRead);

            return inventoryData;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }


    public static void SaveCardsData(CartesPickedUpList cartesPickedUp)
    {
        string jsonPath = Application.persistentDataPath + "/CartesPickedUp.json";
       // InventoryData data = new InventoryData(inventory);

        string json = JsonUtility.ToJson(cartesPickedUp);
        File.WriteAllText(jsonPath, json);
        Debug.Log("cartesPickedUp" + json);
    }

    public static CartesPickedUpList LoadCartes()
    {
        string jsonPath = Application.persistentDataPath + "/CartesPickedUp.json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            CartesPickedUpList cartes = JsonUtility.FromJson<CartesPickedUpList>(jsonRead);
           // JsonUtility.FromJsonOverwrite(jsonRead, cartes);
            for (int i = 0; i < cartes.cartesPickedUps.Count; i++)
            {
                Debug.Log("Load " + cartes.cartesPickedUps[i].cardName);
            }
            return cartes;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }
}
