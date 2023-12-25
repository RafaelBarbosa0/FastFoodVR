using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject circleObj;
    [SerializeField]
    private FriesProgressCircle circle;

    private bool inOil;

    public bool InOil { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Oil")
        {
            InOil = true;

            circleObj.SetActive(true);
            circle.StartChecking();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Oil")
        {
            InOil = false;

            circle.StopChecking();
        }
    }
}
