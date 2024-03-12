// 2024-01-24 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{
    public string filePath = Application.streamingAssetsPath + "/data/";
    private List<string> buttonPresses = new List<string>();
    private long previousPressTime = 0;
    private static Saver instance;

    public static Saver Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject saverObj = new GameObject("Saver");
                instance = saverObj.AddComponent<Saver>();
                DontDestroyOnLoad(saverObj);
            }
            return instance;
        }
    }

    public void RecordButtonPress(string buttonName)
    {
        long currentTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        string sceneName = SceneManager.GetActiveScene().name;

        long reactionTime = 0;
        if (previousPressTime != 0)
        {
            reactionTime = currentTime - previousPressTime;
        }

        string buttonPressInfo = $"{buttonName},{currentTime},{sceneName},{reactionTime}";
        buttonPresses.Add(buttonPressInfo);

        previousPressTime = currentTime;
    }

    public void SaveButtonPresses()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("SubjectNumber,Sex,Age,Education,ButtonName,Time,SceneName,ReactionTime");

        foreach (string buttonPress in buttonPresses)
        {
            string[] pressInfo = buttonPress.Split(',');
            sb.AppendLine($"{UserData.instance.SubjectNumber},{UserData.instance.Sex},{UserData.instance.Age},{UserData.instance.Education},{pressInfo[0]},{pressInfo[1]},{pressInfo[2]},{pressInfo[3]}");
        }

        try
        {
            string fileName = $"{UserData.instance.SubjectNumber}_{System.DateTime.Now:yyyyMMdd_HHmmss}.csv";
            string buttonFilePath = Path.Combine(filePath, fileName);
            File.WriteAllText(buttonFilePath, sb.ToString());
            Debug.Log("Button presses saved successfully.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error saving button presses: " + e.Message);
        }
    }

    private void OnApplicationQuit()
    {
        SaveButtonPresses();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
