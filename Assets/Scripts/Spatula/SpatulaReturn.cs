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
        rb.isKinematic = false;
    }

    public void ReturnSpatula()
    {
        rb.isKinematic = true;

        transform.localPosition = returnPoint.localPosition;
        transform.localRotation = Quaternion.identity;
    }
}
