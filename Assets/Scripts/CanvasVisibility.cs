using UnityEngine;

using UnityEngine.UI;

public class CanvasVisibility : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketInteractor;
    public Canvas[] canvases;
    private Canvas currentCanvas = null;

    private void Start()
    {
        // Ensure all canvases are initially invisible.
        foreach (Canvas canvas in canvases)
        {
            canvas.enabled = false;
        }
    }

    private void Update()
    {
        if (socketInteractor)
        {
            // Check which Canvas the viewer is looking at.
            Canvas newCanvas = GetCanvasInGaze();

            if (newCanvas != currentCanvas)
            {
                // Hide the previously looked-at Canvas.
                if (currentCanvas != null)
                {
                    currentCanvas.enabled = false;
                    Debug.Log("Hiding Canvas: " + currentCanvas.name);
                }
                else
                {
                    Debug.Log("No previous Canvas to hide.");
                }

                // Show the new Canvas that the viewer is looking at.
                if (newCanvas != null)
                {
                    newCanvas.enabled = true;
                    Debug.Log("Showing Canvas: " + newCanvas.name);
                }
                else
                {
                    Debug.Log("No new Canvas to show.");
                }

                currentCanvas = newCanvas;
            }
        }
        else
        {
            Debug.Log("Socket Interactor is not assigned.");
        }
    }

    private Canvas GetCanvasInGaze()
    {
        RaycastHit hit;
        Ray ray = new Ray(socketInteractor.transform.position, socketInteractor.transform.forward);

        foreach (Canvas canvas in canvases)
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == canvas.gameObject)
            {
                Debug.Log("Raycast hit Canvas: " + canvas.name);
                return canvas;
            }
        }

        return null;
    }
}
