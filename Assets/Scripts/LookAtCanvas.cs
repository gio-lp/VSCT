using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LookAtCanvas : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject canvasToDisplay;
    public float maxAngleDifference = 30.0f; // Set your desired maximum angle difference.

    private bool isLookingAtCanvas = false;

    private void Update()
    {
        Vector3 toCanvas = canvasToDisplay.transform.position - playerCamera.transform.position;
        float angleToCanvas = Vector3.Angle(playerCamera.transform.forward, toCanvas);

        if (angleToCanvas < maxAngleDifference / 2.0f)
        {
            // Player is looking at the Canvas
            isLookingAtCanvas = true;
        }
        else
        {
            // Player is not looking at the Canvas
            isLookingAtCanvas = false;
        }

        // Display or hide the canvas based on whether the player is looking at it
        canvasToDisplay.SetActive(isLookingAtCanvas);
    }
}
