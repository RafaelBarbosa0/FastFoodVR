using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSlot : MonoBehaviour
{
    public enum DRINKTYPE
    {
        EMPTY,
        DRINKONE,
        DRINKTWO,
        DRINKTHREE,
        DRINKFOUR
    }

    [SerializeField]
    private DRINKTYPE drinkType;

    [SerializeField]
    private MeshRenderer lightRenderer;
    [SerializeField]
    private Material offMat;
    [SerializeField]
    private Material onMat;

    private bool slotted;// Is a drink slotted into this slot.

    public DRINKTYPE DrinkType { get => drinkType; private set => drinkType = value; }
    public bool Slotted { get => slotted; set => slotted = value; }

    public void SetLightOn()
    {
        lightRenderer.material = onMat;
    }

    public void SetLightOff()
    {
        lightRenderer.material = offMat;
    }
}
