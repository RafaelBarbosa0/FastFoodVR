using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrySlot : MonoBehaviour
{
    private Tray tray;

    private void Start()
    {
        tray = transform.parent.GetComponent<Tray>();
    }

    public void SetTrayFries(FryBox box)
    {
        tray.FryBox = box;
    }

    public void RemoveTrayFries()
    {
        tray.FryBox = null;
    }
}
