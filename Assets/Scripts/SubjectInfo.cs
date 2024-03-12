using UnityEngine;

[CreateAssetMenu(fileName = "SubjectInfo", menuName = "Subject Information")]
public class SubjectInfo : ScriptableObject
{
    public string subjectNumber = "DefaultSubjectNumber";
    public string sex = "Male";
    public int age = 30;
    public string education = "Bachelor's Degree";
}
