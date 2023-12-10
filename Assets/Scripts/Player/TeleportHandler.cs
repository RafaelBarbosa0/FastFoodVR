using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportHandler : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty activateTeleportRay;

    [SerializeField]
    private GameObject teleportRay;

    private void Update()
    {
        Vector2 analogValue = activateTeleportRay.action.ReadValue<Vector2>();
        if (analogValue.y > 0 && !teleportRay.activeInHierarchy)
        {
            teleportRay.SetActive(true);
        }
        else if (analogValue.y <= 0 && teleportRay.activeInHierarchy)
        {
            teleportRay.SetActive(false);
        }
    }
}
