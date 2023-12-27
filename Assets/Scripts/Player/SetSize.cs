using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetSize : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty changeHeightAction;

    [SerializeField]
    private XROrigin origin;
    [SerializeField]
    private float defaultHeight;
    [SerializeField]
    private float heightIncrement;

    private bool changed;

    private void Start()
    {
        origin.CameraYOffset = defaultHeight;
    }

    private void Update()
    {
        Vector2 analogValue = changeHeightAction.action.ReadValue<Vector2>();

        if(analogValue.y == 0) changed = false;

        else if(analogValue.y > 0 && !changed)
        {
            changed = true;

            origin.CameraYOffset += heightIncrement;
        }

        else if (analogValue.y < 0 && !changed)
        {
            changed = true;

            origin.CameraYOffset -= heightIncrement;
        }
    }
}
