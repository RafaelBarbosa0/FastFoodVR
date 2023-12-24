using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookStatus : MonoBehaviour
{
    [SerializeField]
    private Image progressCircle;

    [SerializeField]
    private SideCooking side;// Get cook state change values.

    private float yellowTreshold;// When bar changes to green.
    private float greenTreshold;// When bar changes to red.

    private bool isActive;// If progress circle should be displayed.

    private void Start()
    {
        yellowTreshold = side.MinCook;
        greenTreshold = side.MaxCook;
    }

    private void Update()
    {
        if(isActive)
        {
            // Set image fill.
            progressCircle.fillAmount = side.CookAmount;

            // Set color of bar to give feedback on burger cooking.
            // Yellow means not ready, green means cooked and red mean overcooked.
            if (side.CookAmount < yellowTreshold) progressCircle.color = Color.yellow;
            else if(side.CookAmount >= yellowTreshold && side.CookAmount < greenTreshold) progressCircle.color = Color.green;
            else progressCircle.color = Color.red;
        }
    }

    public void StartChecking()
    {
        isActive = true;
    }

    public void StopChecking()
    {
        isActive = false;
    }
}
