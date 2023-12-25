using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryBox : MonoBehaviour
{
    public enum FrySize
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    [SerializeField]
    private FrySize size;

    [SerializeField]
    private int maxScoops;
    private int currentScoops;

    [SerializeField]
    private GameObject[] fryModels;

    public bool Full => currentScoops == maxScoops;

    public FrySize Size { get => size; set => size = value; }

    public void AddScoop()
    {
        fryModels[currentScoops].SetActive(true);

        currentScoops++;
    }
}
