using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketStatus : MonoBehaviour
{
    private bool inOil;

    public bool InOil { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Oil")
        {
            InOil = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Oil")
        {
            InOil = false;
        }
    }
}
