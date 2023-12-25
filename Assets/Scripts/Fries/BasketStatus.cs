using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject circleObj;
    [SerializeField]
    private FriesProgressCircle circle;

    [SerializeField]
    private Frying frying;

    private bool inOil;

    public bool InOil { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Oil" && frying.HasFries)
        {
            // Basket is in oil.
            InOil = true;

            // Set progress circle.
            circleObj.SetActive(true);
            circle.StartChecking();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Oil")
        {
            // Basket if out of oil.
            InOil = false;

            // Remove progress circle.
            circle.StopChecking();
        }
    }
}
