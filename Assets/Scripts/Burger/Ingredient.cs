using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum IngredientType
    {
        IngredientOne,
        IngredientTwo,
        IngredientThree,
        IngredientFour,
        IngredientFive
    }

    [SerializeField]
    private IngredientType type;

    public IngredientType Type { get => type; private set => type = value; }
}
