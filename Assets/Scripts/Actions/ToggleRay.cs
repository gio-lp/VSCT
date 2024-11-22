using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/// <summary>
/// Toggle between the direct and ray interactor if the direct interactor isn't touching any objects
/// Should be placed on a ray interactor
/// </summary>
[RequireComponent(typeof(XRRayInteractor))]
public class ToggleRay : MonoBehaviour
{
    [Tooltip("Switch even if an object is selected")]
    public bool forceToggle = false;

    [Tooltip("The direct interactor that's switched to")]
    public XRDirectInteractor directInteractor = null;

    private XRRayInteractor rayInteractor = null;
    private bool isSwitched = false;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        SwitchInteractors(false); // Initialize with ray interactor disabled
    }

    public void ActivateRay()
    {
        if (!TouchingObject() || forceToggle)
            SwitchInteractors(true);
    }

    public void DeactivateRay()
    {
        if (isSwitched)
            SwitchInteractors(false);
    }

    private bool TouchingObject()
    {
        // Use List<IXRInteractable> instead of List<XRBaseInteractable> to match the updated method signature
        List<IXRInteractable> targets = new List<IXRInteractable>();
        directInteractor.GetValidTargets(targets);

        // Return true if there are any valid targets, meaning the direct interactor is touching something
        return targets.Count > 0;
    }

    private void SwitchInteractors(bool value)
    {
        isSwitched = value;
        rayInteractor.enabled = value;
        directInteractor.enabled = !value;
    }
}
