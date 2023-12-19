using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCooking : MonoBehaviour
{
    private bool isCooking;// Is this burger side currently being cooked.

    [SerializeField]
    private float cookAmount;// how cooked is this side, from 0 to 1 for lerping.

    [SerializeField]
    private float cookSpeed;

    public bool IsCooking { get => isCooking; set => isCooking = value; }
    public float CookAmount
    {
        get => cookAmount;

        set
        {
            if(cookAmount < 0) cookAmount = 0;
            else if (cookAmount > 1) cookAmount = 1;
            else cookAmount = value;
        }
    }

    private void Update()
    {
        if (isCooking)
        {
            CookAmount += cookSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grill")
        {
            isCooking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Grill")
        {
            isCooking = false;
        }
    }
}
