using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    private bool canSwitchScene = true; // Add a boolean flag
    private void Start()
    {
        MainManager.Instance.Init();
    }

    public void OnButtonClick()
    {
        if (canSwitchScene)
        {
            var mainManager=MainManager.Instance;
            mainManager.LoadNextScene();
            canSwitchScene = false; // Prevent further scene switches until the button is pressed again
        }
    }
}
