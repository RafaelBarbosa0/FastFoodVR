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

    public DRINKTYPE DrinkType { get => drinkType; private set => drinkType = value; }

    public void SetLightOn()
    {
        lightRenderer.material = onMat;
    }

    public void SetLightOff()
    {
        lightRenderer.material = offMat;
    }
}
