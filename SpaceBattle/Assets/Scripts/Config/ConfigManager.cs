using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConfigManager : MonoBehaviour 
{
    private WeaponConfig[] PlayerWeaponsData;
    private string ConfigFileName = "Player.json";

	void Start () 
    {
        LoadConfig();
	}
	
	void Update () 
    {
        
	}

    void LoadConfig()
    {
        string ConfigPath = Path.Combine(Application.streamingAssetsPath, ConfigFileName);

        if (File.Exists(ConfigPath))
        {
            string ConfigDataAsJSON = File.ReadAllText(ConfigPath);
            PlayerConfig loadedData = JsonUtility.FromJson<PlayerConfig>(ConfigDataAsJSON);

            PlayerWeaponsData = loadedData.PlayerWeaponsData;
        }
        else
            Debug.LogError(ConfigFileName + " does not exist at " + Application.streamingAssetsPath);
    }
}
