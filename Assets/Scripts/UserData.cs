// 2024-01-24 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData instance;

    public string SubjectNumber { get; set; }
    public string Sex { get; set; }
    public string Age { get; set; }
    public string Education { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
