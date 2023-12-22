using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookStatus : MonoBehaviour
{
    [SerializeField]
    private Image progressCircle;

    [SerializeField]
    private SideCooking side;

    [SerializeField]
    private float yellowTreshold;
    [SerializeField]
    private float greenTreshold;

    private bool isChecking;

    private void Update()
    {
        if(isChecking)
        {
            progressCircle.fillAmount = side.CookAmount;

            if (side.CookAmount < yellowTreshold) progressCircle.color = Color.yellow;
            else if(side.CookAmount >= yellowTreshold && side.CookAmount < greenTreshold) progressCircle.color = Color.green;
            else progressCircle.color = Color.red;
        }
    }

    public void StartChecking()
    {
        isChecking = true;
    }

    public void StopChecking()
    {
        isChecking = false;
    }
}
