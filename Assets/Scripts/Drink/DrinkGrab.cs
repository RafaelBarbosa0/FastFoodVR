using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrinkGrab : XRGrabInteractable
{
    [SerializeField]
    private Drink drink;

    private MachineSlot machineSlot;

    [SerializeField]
    private Rigidbody rb;

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if(machineSlot != null && !drink.IsFull)
        {
            Vector3 pos = machineSlot.transform.position;
            transform.position = pos;
            transform.rotation = Quaternion.identity;

            machineSlot.SetLightOn();

            drink.SetDrinkType(machineSlot.DrinkType);
            drink.SetCurrentSlot(machineSlot);
            drink.StartFilling();

            this.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MachineSlot")
        {
            machineSlot = other.GetComponent<MachineSlot>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "MachineSlot")
        {
            machineSlot = null;
        }
    }
}
