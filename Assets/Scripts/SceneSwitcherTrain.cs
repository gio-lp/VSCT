using UnityEngine;
using UnityEngine.UI;

public class SceneSwitcherTrain : MonoBehaviour
{
    private bool canSwitchScene = true; // Add a boolean flag

    private void Start()
    {
        MainManagerTrain.Instance.Init();

        // Automatically trigger scene switch after 10 seconds
        Invoke("AutoSwitchScene", 20f);
    }

    private void AutoSwitchScene()
    {
        if (canSwitchScene)
        {
            var mainManager = MainManagerTrain.Instance;
            mainManager.LoadNextScene();
            canSwitchScene = false; // Prevent further scene switches until the button is pressed again
        }
    }

    public void OnButtonClick()
    {
        if (canSwitchScene)
        {
            var mainManager = MainManagerTrain.Instance;
            mainManager.LoadNextScene();
            canSwitchScene = false; // Prevent further scene switches until the button is pressed again
        }
    }
}
