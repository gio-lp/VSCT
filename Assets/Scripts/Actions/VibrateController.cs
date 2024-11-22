﻿using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Vibrate the XR Controller
/// </summary>
public class VibrateController : MonoBehaviour
{
    public float strongVibrate = 0.75f;
    public float weakVibrate = 0.25f;
    [System.Obsolete]
    private XRController controller = null;

    [System.Obsolete]
    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    [System.Obsolete]
    public void Vibrate(float amplitude, float duration)
    {
        // OpenVR currently only supports amplitude
        controller.SendHapticImpulse(amplitude, duration);
    }

    [System.Obsolete]
    public void VibrateWeak(float duration)
    {
        controller.SendHapticImpulse(weakVibrate, duration);
    }

    [System.Obsolete]
    public void VibrateStrong(float duration)
    {
        controller.SendHapticImpulse(strongVibrate, duration);
    }
}
