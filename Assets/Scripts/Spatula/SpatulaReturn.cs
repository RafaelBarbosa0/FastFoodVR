using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaReturn : MonoBehaviour
{
    [SerializeField]
    private Transform returnPoint;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void PickUpSpatula()
    {
        // Rigidbody is not kinematic when player is interacting with it.
        rb.isKinematic = false;
    }

    public void ReturnSpatula()
    {
        // When player drops spatula, make rigidbody kinematic and return it to its default position.
        rb.isKinematic = true;

        transform.localPosition = returnPoint.localPosition;
        transform.localRotation = Quaternion.identity;
    }
}
