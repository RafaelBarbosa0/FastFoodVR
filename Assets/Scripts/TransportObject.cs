using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TransportObject : MonoBehaviour
{
    [SerializeField]
    private string objectTag;

    [SerializeField]
    private Transform transportPoint;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == objectTag)
        {
            BurgerStatus grabStatus = other.GetComponent<BurgerStatus>();
            if (grabStatus.IsGrabbing) return;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            other.transform.position = transportPoint.position;
            other.transform.rotation = Quaternion.identity;
        }
    }
}
