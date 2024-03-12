using UnityEngine;
using UnityEngine.UI;

public class UpdateSubjectInfo : MonoBehaviour
{
    public SubjectInfo subjectInfo; // Reference to your SubjectInfo scriptable object

    public InputField subjectNumberInput;
    public InputField sexInput;
    public InputField ageInput;
    public InputField educationInput;

    public void UpdateSubject()
    {
        if (subjectInfo == null)
        {
            Debug.LogWarning("SubjectInfo reference not set!");
            return;
        }

        // Update values based on input field text
        if (!string.IsNullOrEmpty(subjectNumberInput.text))
        {
            subjectInfo.subjectNumber = subjectNumberInput.text;
        }

        if (!string.IsNullOrEmpty(sexInput.text))
        {
            subjectInfo.sex = sexInput.text;
        }

        if (!string.IsNullOrEmpty(ageInput.text))
        {
            int ageValue;
            if (int.TryParse(ageInput.text, out ageValue))
            {
                subjectInfo.age = ageValue;
            }
            else
            {
                Debug.LogWarning("Invalid age input!");
            }
        }

        if (!string.IsNullOrEmpty(educationInput.text))
        {
            subjectInfo.education = educationInput.text;
        }
    }
}
