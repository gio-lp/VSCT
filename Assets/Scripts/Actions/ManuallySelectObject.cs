using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/// <summary>
/// This script either forces the selection or deselection of an interactable object by the interactor this script is on.
/// </summary>
public class ManuallySelectObject : MonoBehaviour
{
    [Tooltip("What object are we selecting?")]
    public XRBaseInteractable interactable = null;

    private XRBaseInteractor interactor = null;
    private XRInteractionManager interactionManager = null;

    private void Awake()
    {
        // Get the interactor component and interaction manager
        interactor = GetComponent<XRBaseInteractor>();
        interactionManager = interactor.interactionManager;
    }

    public void ManuallySelect()
    {
        // Enable the interactable object
        interactable.gameObject.SetActive(true);

        // Use the updated SelectEnter method to manually select the interactable
        interactionManager.SelectEnter((IXRSelectInteractor)interactor, (IXRSelectInteractable)interactable);
    }

    public void ManuallyDeselect()
    {
        // Use the updated SelectExit method to deselect
        interactionManager.SelectExit((IXRSelectInteractor)interactor, (IXRSelectInteractable)interactable);

        // Deactivate the interactable object
        interactable.gameObject.SetActive(false);
    }
}
