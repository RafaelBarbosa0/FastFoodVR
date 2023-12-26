using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public enum DRINKSIZE
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    [SerializeField]
    private DRINKSIZE size;

    [SerializeField]
    private MachineSlot.DRINKTYPE type;

    [SerializeField]
    private float maxDrink;
    [SerializeField]
    private float currentDrink;

    [SerializeField]
    private float fillSpeed;
    private bool filling;

    private MachineSlot currentSlot;

    [SerializeField]
    private GameObject cap;

    private DrinkGrab grab;

    public bool IsFull => currentDrink == maxDrink;

    public DRINKSIZE Size { get => size; private set => size = value; }
    public MachineSlot.DRINKTYPE Type { get => type; private set => type = value; }
    public bool Filling { get => filling; private set => filling = value; }

    public float CurrentDrink
    {
        get { return currentDrink; }
        private set
        {
            if (value < 0) currentDrink = 0;
            else if (value > maxDrink) currentDrink = maxDrink;
            else currentDrink = value;
        }
    }

    private void Start()
    {
        grab = GetComponent<DrinkGrab>();
    }

    private void Update()
    {
        if (filling)
        {
            CurrentDrink += fillSpeed * Time.deltaTime;

            if (IsFull)
            {
                filling = false;
                currentSlot.SetLightOff();
                currentSlot = null;

                cap.SetActive(true);
                grab.enabled = true;
            }
        }
    }

    public void StartFilling()
    {
        filling = true;
    }

    public void SetDrinkType(MachineSlot.DRINKTYPE drinkType)
    {
        type = drinkType;
    }

    public void SetCurrentSlot(MachineSlot slot)
    {
        currentSlot = slot;
    }
}
