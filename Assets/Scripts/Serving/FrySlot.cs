using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrySlot : MonoBehaviour
{
    private Tray tray;

    private bool slotted;

    public bool Slotted { get => slotted; private set => slotted = value; }

    private void Start()
    {
        tray = transform.parent.GetComponent<Tray>();
    }

    public void SetTrayFries(FryBox box)
    {
        tray.FryBox = box;
        slotted = true;
    }

    public void RemoveTrayFries()
    {
        tray.FryBox = null;
        slotted = false;
    }
}
