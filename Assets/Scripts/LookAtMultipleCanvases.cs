using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LookAtMultipleCanvases : MonoBehaviour
{
    public Camera playerCamera;
    public List<Canvas> canvasesToDisplay;
    public float maxAngleDifference = 30.0f; // Set your desired maximum angle difference.

    private Canvas currentCanvas = null;

    private void Update()
    {
        bool isLookingAtAnyCanvas = false;

        foreach (Canvas canvas in canvasesToDisplay)
        {
            Vector3 toCanvas = canvas.transform.position - playerCamera.transform.position;
            float angleToCanvas = Vector3.Angle(playerCamera.transform.forward, toCanvas);

            if (angleToCanvas < maxAngleDifference / 2.0f)
            {
                // Player is looking at one of the Canvas objects
                isLookingAtAnyCanvas = true;
                currentCanvas = canvas; // Set the current Canvas the player is looking at.
                break; // No need to check other Canvas objects, exit the loop.
            }
        }

        if (isLookingAtAnyCanvas)
        {
            // Player is looking at one of the Canvas objects
            currentCanvas.enabled = true;
        }
        else
        {
            // Player is not looking at any of the Canvas objects
            if (currentCanvas != null)
            {
                currentCanvas.enabled = false;
                currentCanvas = null;
            }
        }
    }
}
