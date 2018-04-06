using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConfigManager : MonoBehaviour 
{
    [SerializeField]
    PlayerConfig ConfigData;

    [SerializeField]
    private bool inConfigScene;

    private ShipConfig[] PlayerShipsData;
    private string ConfigFileName = "Player.json";

	void Start () 
    {
        LoadConfig();
	}
	
	void Update () 
    {
        // Auto save
        if (inConfigScene)
        {
            SaveConfig();
            LoadConfig();
        }
	}

    void LoadConfig()
    {
        string ConfigPath = Path.Combine(Application.streamingAssetsPath, ConfigFileName);

        if (File.Exists(ConfigPath))
        {
            string ConfigDataAsJSON = File.ReadAllText(ConfigPath);
            PlayerConfig loadedConfigData = JsonUtility.FromJson<PlayerConfig>(ConfigDataAsJSON);

            PlayerShipsData = loadedConfigData.PlayerShipsData;
        }
        else
        {
            ConfigData = new PlayerConfig();            
        }
    }


    private void SaveConfig()
    {
        string ConfigDataAsJSON = JsonUtility.ToJson(ConfigData);
        string ConfigPath = Path.Combine(Application.streamingAssetsPath, ConfigFileName);

        File.WriteAllText(ConfigPath, ConfigDataAsJSON);
    }

}
