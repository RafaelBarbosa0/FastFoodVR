using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BasketGrab : XRGrabInteractable
{
    [SerializeField]
    private BasketStatus status;

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (!status.InOil)
        {
            GetComponent<ObjectReturn>().ReturnObject();
        }
    }
}
