using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hourHandTransform;
    public Transform minuteHandTransform;
    public Transform secondHandTransform;

    void Update()
    {
        float hours = System.DateTime.Now.Hour % 12;  // Convert to 12-hour format
        float minutes = System.DateTime.Now.Minute;
        float seconds = System.DateTime.Now.Second;

        // Calculate rotations for each hand
        float hourRotation = hours * 30f;  // Each hour represents 30 degrees
        float minuteRotation = minutes * 6f;  // Each minute represents 6 degrees
        float secondRotation = seconds * 6f;  // Each second represents 6 degrees

        // Rotate the clock hands on the X-axis
        hourHandTransform.rotation = Quaternion.identity;
        minuteHandTransform.rotation = Quaternion.identity;
        secondHandTransform.rotation = Quaternion.identity;

        hourHandTransform.Rotate(Vector3.right, hourRotation);
        minuteHandTransform.Rotate(Vector3.right, minuteRotation);
        secondHandTransform.Rotate(Vector3.right, secondRotation);
    }
}
