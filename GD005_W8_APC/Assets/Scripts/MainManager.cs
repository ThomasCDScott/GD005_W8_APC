using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color unitColor;

    public void Awake()
    {
        //makes sure that there is always one copy of the object
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        //define the current object as Instance
        Instance = this;

        //makes the object presistent between scenes
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public Color _unitColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data._unitColor = unitColor;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            unitColor = data._unitColor;
        }
    }
}
