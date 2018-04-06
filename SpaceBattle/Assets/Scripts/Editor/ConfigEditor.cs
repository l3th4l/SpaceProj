using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ConfigEditor : EditorWindow
{
    public PlayerConfig ConfigData;

    private string ConfigProjectFilePath = "/StreamingAssets/Player.json";

    private void LoadConfig()
    {
        string ConfigPath = Application.dataPath + ConfigProjectFilePath;

        if(File.Exists(ConfigPath))
        {
            string ConfigDataAsJSON = File.ReadAllText(ConfigPath);

            ConfigData = JsonUtility.FromJson<PlayerConfig>(ConfigDataAsJSON);
        }
        else
        {
            ConfigData = new PlayerConfig();
        }
    }

    private void SaveData()
    {
        string ConfigDataAsJSON = JsonUtility.ToJson(ConfigData);
        string ConfigPath = Application.dataPath + ConfigProjectFilePath;

        File.WriteAllText(ConfigPath, ConfigDataAsJSON);
    }
}
