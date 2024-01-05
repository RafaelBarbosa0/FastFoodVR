using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryReserve : MonoBehaviour
{
    private int scoops;
    [SerializeField]
    private int maxScoops;

    private Vector3 startingScale;

    [SerializeField]
    private Vector3 scaleAdjust;

    public bool IsFull => scoops == maxScoops;

    private void Start()
    {
        startingScale = transform.localScale;

        gameObject.SetActive(false);
    }

    public void SetScoops()
    {
        scoops = maxScoops;

        transform.localScale = startingScale;

        AudioManager.Instance.PlaySFX("Fry", true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Scoop") && scoops > 0)
        {
            Scoop scoop = other.GetComponent<Scoop>();
            if (!scoop.Filled)// If scoop doesn't already have fries on it.
            {
                AudioManager.Instance.PlaySFX("Fry", true);

                scoop.SetScoop();
                scoops--;

                if(scoops <= 0) gameObject.SetActive(false);// When fries run out.

                else
                {
                    transform.localScale -= scaleAdjust;
                }
            }
        }
    }
}
