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
        scenes = new List<string>(scenesToVisit); // Initialize scenes with a copy of scenesToVisit.

        // Initialize the list of scenes to visit if it's not set.
        if (scenesToVisit.Count == 0)
        {
            Debug.LogWarning("No scenes to visit added to the MainManagerTrain. Please add scenes in the Inspector.");
            // No need to disable the entire script, just the scene loading part.
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
        if (canLoadScene && scenesToVisit.Count > 0)
        {
            string nextScene = scenesToVisit[0];
            Scene scene = SceneManager.GetActiveScene();
            var sceneName = scene.name;
            int i = 1;
            while (nextScene == sceneName && i < scenesToVisit.Count)
            {
                nextScene = scenesToVisit[i++];
            }

            SceneManager.LoadScene(nextScene);
            canLoadScene = false; // Disable further scene loading until the next call to LoadNextScene.
        }
    }

    // Shuffle method remains unchanged.
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