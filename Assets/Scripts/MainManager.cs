using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public List<string> scenesToVisit; // Add scene names you want to visit in the Inspector.
    private List<string> scenes;
    private bool canLoadScene = false; // Add a control flag
    public int sequenceCount = 3;
    private int currentSequenceNumber = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        scenes= new List<string>(scenesToVisit);
        
        // Initialize the list of scenes to visit if it's not set.
        if (scenesToVisit.Count == 0)
        {
            Debug.LogWarning("No scenes to visit added to the MainManager. Please add scenes in the Inspector.");
        }
    }

    public void Init()
    {
        if (currentSequenceNumber < sequenceCount)
        {
            Scene scene = SceneManager.GetActiveScene();
            var sceneName = scene.name;
            scenesToVisit.Remove(sceneName);
            if (scenesToVisit.Count == 0)
            {
                currentSequenceNumber++;
                // If we've completed the required number of sequences, stop the scene loading.
                if (currentSequenceNumber >= sequenceCount)
                {
                    canLoadScene = false; // Prevent any more scene loading.
                    return; // Exit the method.
                }
                scenesToVisit.AddRange(scenes); // Re-populate the list of scenes.
            }
        }

        Shuffle(scenesToVisit); // Shuffle remains the same.
    }

    private void Update()
    {
        // Check if there are scenes left to visit and if loading is allowed.
        if (canLoadScene && scenesToVisit.Count > 0)
        {
            // Get the next scene to visit.
            string nextScene = scenesToVisit[0];
            Scene scene = SceneManager.GetActiveScene();
            var sceneName = scene.name;
            int i = 1;
            while (nextScene == sceneName && i<scenesToVisit.Count)
            {
                nextScene = scenesToVisit[i++];
            }
                // Load the next scene.
                SceneManager.LoadScene(nextScene);

            // Disable further scene loading until the button press.
            canLoadScene = false;
        }
    }

    // Fisher-Yates Shuffle algorithm to randomize the list of scenes.
    private void Shuffle(List<string> list) { /* ... */ }

    internal void LoadNextScene()
    {
        // Only allow scene loading if we haven't reached the sequence count.
        if (currentSequenceNumber < sequenceCount)
        {
            canLoadScene = true;
        }
    }
}
