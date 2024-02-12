using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private void Start()
    {
        try
        {
            string json = File.ReadAllText(Application.dataPath + "/playerData.json");
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            dropdown.value = data.lang;
        }
        catch
        {

        }
    }
    private void Update()
    {
        PlayerData playerData = new PlayerData();
        playerData.lang = dropdown.value;
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(Application.dataPath + "/playerData.json", json);
    }
}
