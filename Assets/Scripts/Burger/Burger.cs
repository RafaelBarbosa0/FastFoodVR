using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    [SerializeField]
    private int pattyAmount;
    [SerializeField]
    private int ingredientOneAmount;
    [SerializeField]
    private int ingredientTwoAmount;
    [SerializeField]
    private int ingredientThreeAmount;
    [SerializeField]
    private int ingredientFourAmount;
    [SerializeField]
    private int ingredientFiveAmount;

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
                case Ingredient.IngredientType.IngredientOne: 
                    ingredientOneAmount++; 
                    break;
                case Ingredient.IngredientType.IngredientTwo: 
                    ingredientTwoAmount++; 
                    break;
                case Ingredient.IngredientType.IngredientThree: 
                    ingredientThreeAmount++; 
                    break;
                case Ingredient.IngredientType.IngredientFour:
                    ingredientFourAmount++;
                    break;
                case Ingredient.IngredientType.IngredientFive:
                    ingredientFiveAmount++;
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
                case Ingredient.IngredientType.IngredientOne:
                    ingredientOneAmount--;
                    break;
                case Ingredient.IngredientType.IngredientTwo:
                    ingredientTwoAmount--;
                    break;
                case Ingredient.IngredientType.IngredientThree:
                    ingredientThreeAmount--;
                    break;
                case Ingredient.IngredientType.IngredientFour:
                    ingredientFourAmount--;
                    break;
                case Ingredient.IngredientType.IngredientFive:
                    ingredientFiveAmount--;
                    break;
            }
        }
    }
}
