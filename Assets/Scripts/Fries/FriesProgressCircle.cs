using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriesProgressCircle : MonoBehaviour
{
    private Frying frying;

    private float minTreshold;
    private float maxTreshold;

    [SerializeField]
    private GameObject progressObject;
    [SerializeField]
    private Image progressCircle;

    private bool isChecking;

    private void Start()
    {
        frying = GetComponent<Frying>();

        minTreshold = frying.MinFry;
        maxTreshold = frying.MaxFry;

        progressCircle.color = Color.yellow;
    }

    private void Update()
    {
        if (isChecking)
        {
            progressCircle.fillAmount = frying.FryStatus;

            if (progressCircle.fillAmount > minTreshold && progressCircle.fillAmount < maxTreshold) progressCircle.color = Color.green;
            else if (progressCircle.fillAmount > maxTreshold) progressCircle.color = Color.red;
        }
    }

    public void StartChecking()
    {
        isChecking = true;
    }

    public void StopChecking()
    {
        isChecking = false;
        progressObject.SetActive(false);
    }
}
