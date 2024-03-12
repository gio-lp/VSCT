// 2024-01-24 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;
using UnityEngine.UI;

public class InputFieldData : MonoBehaviour
{
    public InputField subjectNumberField;
    public InputField sexField;
    public InputField ageField;
    public InputField educationField;

    public void SubmitData()
    {
        UserData.instance.SubjectNumber = subjectNumberField.text;
        UserData.instance.Sex = sexField.text;
        UserData.instance.Age = ageField.text;
        UserData.instance.Education = educationField.text;
    }
}
