using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveScript : MonoBehaviour 
{
    public JsonInfo JsonDataScript = new JsonInfo();

    [SerializeField]private bool dontSave;

    void Start()
    {
        if (!dontSave)
        {
            SaveLVL();
            ToJson();
        }
    }

    public void ToJson()
    {
        string json = JsonUtility.ToJson(JsonDataScript);
        File.WriteAllText("Assets/JsonData.json", json.ToString());
    }

    public void FromJson()
    {
        string dataPath = "Assets/JsonData.json";
        string dataAsJson = File.ReadAllText(dataPath);
        JsonDataScript = JsonUtility.FromJson<JsonInfo>(dataAsJson);
    }

    public void FromJson_ContinueButton()
    {
        FromJson();
        SceneManager.LoadScene(JsonDataScript.levelIndex);
    }

    public void SaveLVL()
    {
        JsonDataScript.levelIndex = SceneManager.GetActiveScene().buildIndex;
    }
}

public class JsonInfo
{ 
    public int levelIndex;
    public int totalCannonShots;
}