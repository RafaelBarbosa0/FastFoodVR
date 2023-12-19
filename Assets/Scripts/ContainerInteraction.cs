using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ContainerInteraction : XRGrabInteractable
{
    [SerializeField]
    private GameObject objectToSpawn;// Object that this container will spawn on interaction.

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Spawn object.
        GameObject obj = Instantiate(objectToSpawn);

        // Get spawned object interactable.
        XRGrabInteractable interactable = obj.GetComponent<XRGrabInteractable>();

        // Enter spawned object select event and exit this select event.
        interactionManager.SelectEnter(args.interactorObject, interactable);
        interactionManager.SelectExit(args.interactorObject, this);
    }
}
