using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    [SerializeField]
    private int pattyAmount;
    [SerializeField]
    private int lettuceAmount;
    [SerializeField]
    private int cheeseAmount;
    [SerializeField]
    private int cowTongueAmount;
    [SerializeField]
    private int greenBristolAmount;
    [SerializeField]
    private int purpleBristolAmount;
    [SerializeField]
    private int bunAmount;

    public int PattyAmount { get => pattyAmount; private set => pattyAmount = value; }
    public int LettuceAmount { get => lettuceAmount; private set => lettuceAmount = value; }
    public int CheeseAmount { get => cheeseAmount; private set => cheeseAmount = value; }
    public int CowTongueAmount { get => cowTongueAmount; private set => cowTongueAmount = value; }
    public int GreenBristolAmount { get => greenBristolAmount; private set => greenBristolAmount = value; }
    public int PurpleBristolAmount { get => purpleBristolAmount; private set => purpleBristolAmount = value; }
    public int BunAmount { get => bunAmount; private set => bunAmount = value; }

    private void OnTriggerEnter(Collider other)
    {
        // Add patty.
        if(other.tag == "Patty")
        {
            PattyStatus patty = other.GetComponent<PattyStatus>();

            if (patty.Cooked) pattyAmount++;
        }

        // Add ingredient.
        if(other.tag == "Ingredient")
        {
            Ingredient ingredient = other.GetComponent<Ingredient>();

            switch (ingredient.Type)
            {
                case Ingredient.IngredientType.LETTUCE: 
                    lettuceAmount++; 
                    break;
                case Ingredient.IngredientType.CHEESE: 
                    cheeseAmount++; 
                    break;
                case Ingredient.IngredientType.COWTONGUE: 
                    cowTongueAmount++; 
                    break;
                case Ingredient.IngredientType.GREENBRISTOL:
                    greenBristolAmount++;
                    break;
                case Ingredient.IngredientType.PURPLEBRISTOL:
                    purpleBristolAmount++;
                    break;
                case Ingredient.IngredientType.BUN:
                    bunAmount++;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove patty.
        if(other.tag == "Patty")
        {
            PattyStatus patty = other.GetComponent<PattyStatus>();

            if (patty.Cooked) pattyAmount--;
        }

        // Remove ingredient.
        if (other.tag == "Ingredient")
        {
            Ingredient ingredient = other.GetComponent<Ingredient>();

            switch (ingredient.Type)
            {
                case Ingredient.IngredientType.LETTUCE:
                    lettuceAmount--;
                    break;
                case Ingredient.IngredientType.CHEESE:
                    cheeseAmount--;
                    break;
                case Ingredient.IngredientType.COWTONGUE:
                    cowTongueAmount--;
                    break;
                case Ingredient.IngredientType.GREENBRISTOL:
                    greenBristolAmount--;
                    break;
                case Ingredient.IngredientType.PURPLEBRISTOL:
                    purpleBristolAmount--;
                    break;
                case Ingredient.IngredientType.BUN:
                    bunAmount--;
                    break;
            }
        }
    }
}
