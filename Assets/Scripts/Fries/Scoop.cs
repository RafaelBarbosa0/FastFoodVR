using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoop : MonoBehaviour
{
    [SerializeField]
    private GameObject fryModel;

    private bool filled;

    public bool Filled { get => filled; private set => filled = value; }

    public void SetScoop()
    {
        fryModel.SetActive(true);
        filled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FryBox" && filled)
        {
            FryBox box = other.transform.parent.GetComponent<FryBox>();

            if (box.Full) return;

            box.AddScoop();

            filled = false;
            fryModel.SetActive(false);
        }
    }
}
