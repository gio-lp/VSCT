using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RandomActionBasedSnapTurnProvider : ActionBasedSnapTurnProvider
{
    protected override Vector2 ReadInput()
    {
        // Call the base ReadInput method to get the input from the controllers
        Vector2 input = base.ReadInput();

        // Check if either the left or right snap turn action is triggered
        if (input.magnitude > 0.1f)
        {
            // Generate a random angle from the list of specified angles
            int[] possibleAngles = { 72, 144 };
            int randomIndex = Random.Range(0, possibleAngles.Length);
            int randomAngle = possibleAngles[randomIndex];
            Debug.Log(randomAngle);

            // Convert the random angle to a rotation vector
            return Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
        }
        return input;
    }
}
