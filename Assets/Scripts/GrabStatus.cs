using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabStatus : MonoBehaviour
{
    private bool isGrabbing;

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
