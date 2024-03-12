using UnityEngine;

public class ButtonRecorder : MonoBehaviour
{
    private static ButtonRecorder instance;

    public static ButtonRecorder Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ButtonRecorder>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("ButtonRecorder");
                    instance = obj.AddComponent<ButtonRecorder>();
                }
            }
            return instance;
        }
    }

    private Saver saver;

    private void Awake()
    {
        saver = FindObjectOfType<Saver>();
    }

    public void RecordButtonPress(string buttonName)
    {
        if (saver != null)
        {
            saver.RecordButtonPress(buttonName);
        }
        else
        {
            Debug.LogWarning("Saver script not found!");
        }
    }
}
