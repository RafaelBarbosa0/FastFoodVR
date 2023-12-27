using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe")]
public class Recipe : ScriptableObject
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

    public int PattyAmount { get => pattyAmount; private set => pattyAmount = value; }
    public int LettuceAmount { get => lettuceAmount; private set => lettuceAmount = value; }
    public int CheeseAmount { get => cheeseAmount; private set => cheeseAmount = value; }
    public int CowTongueAmount { get => cowTongueAmount; private set => cowTongueAmount = value; }
    public int GreenBristolAmount { get => greenBristolAmount; private set => greenBristolAmount = value; }
    public int PurpleBristolAmount { get => purpleBristolAmount; private set => purpleBristolAmount = value; }

}
