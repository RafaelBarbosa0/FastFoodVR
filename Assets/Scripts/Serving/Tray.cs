using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    [SerializeField]
    private Burger burger;

    [SerializeField]
    private FryBox fryBox;

    public FryBox FryBox { get => fryBox; set => fryBox = value; }
}
