using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

public class FileSaveLoadManager : MonoBehaviour
{
    public FpsController fpsController;

    public void Save()
    {
        var filePath = Path.Combine(Application.persistentDataPath, "PlayerDatafile.json");

        if (!File.Exists(filePath))
        {
            var fileStream = File.Create(filePath);
            fileStream.Dispose();
        }

        var PlayerDatafileJonsText = JsonConvert.SerializeObject(fpsController.savePlayerData);
        File.WriteAllText(filePath,PlayerDatafileJonsText);
    }

    public void Load()
    {
        var filePath = Path.Combine(Application.persistentDataPath, "PlayerDatafile.json");

        if (File.Exists(filePath))
        {
            var savePlayerData = JsonConvert.DeserializeObject<SavePlayerData>(File.ReadAllText(filePath));
            fpsController.savePlayerData = savePlayerData;
            fpsController.transform.position = savePlayerData.playerPosition;
            fpsController.transform.rotation = Quaternion.Euler(savePlayerData.playerRotationEuler);
        }
    }
    
}
