using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private int maxLives;
    private int lives;

    private int score;

    [SerializeField]
    private Transform trayParent;
    [SerializeField]
    private Transform ticketParent;

    [SerializeField]
    private GameObject trayPrefab;
    [SerializeField]
    private GameObject ticketPrefab;
    private Tray currentTray;
    private Ticket currentTicket;

    [SerializeField]
    private float ticketTime;
    private float currentTicketTime;

    [SerializeField]
    private TMP_Text ticketTimeText;

    [SerializeField]
    private MeshRenderer[] lifeIndicators;
    [SerializeField]
    private Material onMat;
    private int lightIndex;

    [SerializeField]
    private DestroyOrder destroyOrder;

    private bool gameEnded;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        lives = maxLives;

        StartNewOrder();
    }

    private void Update()
    {
        if(gameEnded) return;

        currentTicketTime -= Time.deltaTime;

        float timeFloored = Mathf.Round(currentTicketTime);
        ticketTimeText.text = timeFloored.ToString();

        if(currentTicketTime <= 0)
        {
            RemoveLife();
            StartNewOrder();
        }
    }

    public void StartNewOrder()
    {
        if(gameEnded) return;

        if (currentTray != null) Destroy(currentTray.gameObject);
        if(currentTicket != null) Destroy(currentTicket.gameObject);

        destroyOrder.DestroyObjects();

        GameObject tray = Instantiate(trayPrefab, trayParent);
        currentTray = tray.GetComponent<Tray>();

        GameObject ticket = Instantiate(ticketPrefab, ticketParent);
        currentTicket = ticket.GetComponent<Ticket>();

        currentTicketTime = ticketTime;
    }

    public void DeliverOrder()
    {
        if (IsOrderCorrect())
        {
            score++;
        }

        else
        {
            RemoveLife();
        }

        StartNewOrder();
    }

    private bool IsOrderCorrect()
    {
        FryBox fries = currentTray.FryBox;
        Drink drink = currentTray.Drink;
        Burger burger = currentTray.Burger;

        // Missing fries or drink.
        if(fries == null || drink == null)
        {
            Debug.Log("null");
            return false;
        }

        // Check fries.
        if(!fries.Full || fries.Size != currentTicket.FrySize)
        {
            Debug.Log("Fry issue");
            Debug.Log(fries.Full);
            Debug.Log(fries.Size);
            Debug.Log(currentTicket.FrySize);
            return false;
        }

        // Check drink.
        if(!drink.IsFull || drink.Size != currentTicket.DrinkSize || drink.Type != currentTicket.DrinkType)
        {
            Debug.Log("Drink issues");
            Debug.Log(drink.IsFull);
            Debug.Log(drink.Size);
            Debug.Log(currentTicket.DrinkSize);
            Debug.Log(drink.Type);
            Debug.Log(currentTicket.DrinkType);
            return false;
        }

        // Check burger.
        if(burger.PattyAmount != currentTicket.PattyAmount || burger.LettuceAmount != currentTicket.LettuceAmount || burger.CheeseAmount != currentTicket.CheeseAmount
            || burger.CowTongueAmount != currentTicket.CowTongueAmount || burger.GreenBristolAmount != currentTicket.GreenBristolAmount || burger.PurpleBristolAmount != currentTicket.PurpleBristolAmount || burger.BunAmount != 1)
        {
            Debug.Log("Burger issue");
            return false;
        }

        // If passed checks order is correct.
        return true;
    }

    private void RemoveLife()
    {
        lives--;

        lifeIndicators[lightIndex].material = onMat;
        lightIndex++;

        if (lives <= 0) EndGame();
    }

    private void EndGame()
    {
        gameEnded = true;
    }
}
