using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaGrab : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        // When spatula head touches burger flop it on top of spatula.
        if(other.tag == "Patty")
        {
            // Return if player is grabbing patty.
            if (other.GetComponent<PattyStatus>().IsGrabbing) return;

            Transform burger = other.transform;

            burger.position = spawnPoint.position;
        }
    }
}
