using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerStatus : MonoBehaviour
{
    [SerializeField]
    private SideCooking top;
    [SerializeField]
    private SideCooking bottom;

    private bool isGrabbing;

    public bool Cooked => (top.IsCooked && bottom.IsCooked);

    public bool IsGrabbing { get => isGrabbing; set => isGrabbing = value; }

    public void StartGrabbing()
    {
        isGrabbing = true;
    }

    public void StopGrabbing()
    {
        isGrabbing = false;
    }
}
