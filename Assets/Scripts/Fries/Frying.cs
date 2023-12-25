using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frying : MonoBehaviour
{
    [SerializeField]
    private BasketStatus status;// To check if basket is in oil.

    [SerializeField]
    private GameObject reservedFries;// To move cooked fries to reserve.

    private FriesProgressCircle circle;

    private bool hasFries;// Are there fries in the basket.

    private bool isFrying => status.InOil && hasFries;

    private float fryStatus;
    [SerializeField]
    private float frySpeed;
    [SerializeField]
    private float minFry;
    [SerializeField]
    private float maxFry;

    private bool isCooked => fryStatus > minFry && fryStatus < maxFry;

    [SerializeField]
    private GameObject fries;
    private MeshRenderer fryRenderer;
    [SerializeField]
    private Material uncooked;
    [SerializeField]
    private Material cooked;
    [SerializeField]
    private Material burnt;

    public float MinFry { get => minFry; private set => minFry = value; }
    public float MaxFry { get => maxFry; private set => maxFry = value; }
    public float FryStatus
    {
        get { return fryStatus; }
        private set
        {
            if (value < 0) fryStatus = 0;
            else if (value > 1) fryStatus = 1;
            else fryStatus = value;
        }
    }

    public bool HasFries { get => hasFries; private set => hasFries = value; }

    private void Start()
    {
        fryRenderer = fries.GetComponent<MeshRenderer>();

        circle = GetComponent<FriesProgressCircle>();
    }

    private void Update()
    {
        if (isFrying)
        {
            FryStatus += frySpeed * Time.deltaTime;

            if (fryStatus > minFry && fryStatus < maxFry && fryRenderer.material != cooked) ChangeFryMat(cooked);
            if (fryStatus > maxFry && fryRenderer.material != burnt) ChangeFryMat(burnt);
        }
    }

    public void SetFries()
    {
        fryStatus = 0;

        hasFries = true;
        fries.gameObject.SetActive(true);

        ChangeFryMat(uncooked);

        circle.ProgressCircle.color = Color.yellow;
    }

    public void RemoveFries()
    {
        hasFries = false;
        fryStatus = 0;
        fries.gameObject.SetActive(false);
    }

    private void ChangeFryMat(Material mat)
    {
        fryRenderer.material = mat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FryBag" && !hasFries)
        {
            SetFries();
        }

        else if (other.tag == "FryReserve" && isCooked)
        {
            if(!reservedFries.activeInHierarchy) reservedFries.SetActive(true);
            FryReserve reserve = reservedFries.GetComponent<FryReserve>();

            if (reserve.IsFull) return;

            RemoveFries();

            reserve.SetScoops();
        }
    }
}
