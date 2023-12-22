using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCooking : MonoBehaviour
{
    private bool isCooking;// Is this burger side currently being cooked.

    private float cookAmount;// how cooked is this side, from 0 to 1 for lerping.

    [SerializeField]
    private float cookSpeed;

    [SerializeField]
    private GameObject model;
    private Material mat;

    private Color startingColor;
    [SerializeField]
    private Color endColor;

    [SerializeField]
    private GameObject cookStatus;

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

    private void Start()
    {
        Material startingMat = model.GetComponent<MeshRenderer>().material;
        mat = Instantiate(startingMat);
        model.GetComponent<MeshRenderer>().material = mat;

        startingColor = mat.color;
    }

    private void Update()
    {
        if (isCooking)
        {
            CookAmount += cookSpeed * Time.deltaTime;

            mat.color = Color.Lerp(startingColor, endColor, cookAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grill")
        {
            isCooking = true;

            cookStatus.SetActive(true);
            cookStatus.GetComponent<CookStatus>().StartChecking();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Grill")
        {
            isCooking = false;

            cookStatus.GetComponent<CookStatus>().StopChecking();
            cookStatus.SetActive(false);
        }
    }
}
