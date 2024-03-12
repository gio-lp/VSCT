using UnityEngine;
using UnityEngine.UI;

public class InstController : MonoBehaviour
{
    public GameObject[] canvases; // Array to hold the canvases in the desired sequence
    public Text resultText; // Reference to a UI Text component to display the result
    private int currentCanvasIndex = 0;
    private int[] userResponses = new int[11]; // Array to hold user responses

    void Start()
    {
        // Show only the first canvas
        ShowCanvas(currentCanvasIndex);
    }

    public void DoClick(int response)
    {
        userResponses[currentCanvasIndex] = response;
        currentCanvasIndex++;

        if (currentCanvasIndex < canvases.Length)
        {
            ShowCanvas(currentCanvasIndex);
        }
        else
        {
            bool allResponsesOne = true;
            foreach (int userResponse in userResponses)
            {
                if (userResponse != 1)
                {
                    allResponsesOne = false;
                    break;
                }
            }

            if (allResponsesOne)
            {
                resultText.text = "Correct!";
            }
            else
            {
                resultText.text = "Try Again!";
            }

            Debug.Log("End of canvases");
            // You've reached the end of canvases, you can handle this as per your requirement
        }
    }

    private void ShowCanvas(int index)
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(i == index);
        }
    }
}
