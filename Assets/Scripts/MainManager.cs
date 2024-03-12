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
        scenes= new List<string>();
        foreach(string s in scenesToVisit)
        {
            scenes.Add(s);
        }
        // Initialize the list of scenes to visit if it's not set.
        if (scenesToVisit.Count == 0)
        {
            Debug.LogWarning("No scenes to visit added to the MainManager. Please add scenes in the Inspector.");
            enabled = false;
        }
    }

    public void Init()
    {
        if (currentSequenceNumber < sequenceCount)
        {
            Scene scene = SceneManager.GetActiveScene();
            var sceneName = scene.name;
            if (scenesToVisit.Contains(sceneName))
                scenesToVisit.Remove(sceneName);
            if (scenesToVisit.Count == 0)
            {
                currentSequenceNumber++;
                foreach (string s in scenes)
                    scenesToVisit.Add(s);
            }
        }
       
        // Shuffle the list of scenes to visit for a random order.
        Shuffle(scenesToVisit);
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
    private void Shuffle(List<string> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    internal void LoadNextScene()
    {
        // Allow scene loading when the button is pressed.
        canLoadScene = true;
    }
}
