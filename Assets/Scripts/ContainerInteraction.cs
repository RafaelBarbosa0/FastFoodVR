using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ContainerInteraction : XRGrabInteractable
{
    [SerializeField]
    private GameObject objectToSpawn;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        Transform parent = args.interactorObject.transform;
        GameObject obj = Instantiate(objectToSpawn);

        XRGrabInteractable interactable = obj.GetComponent<XRGrabInteractable>();
        interactionManager.SelectEnter(args.interactorObject, interactable);

        interactionManager.SelectExit(args.interactorObject, this);
    }
}
