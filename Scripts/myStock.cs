using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Stock", menuName = "Character Stats/Stock")]
public class myStock : ScriptableObject
{
    [Header("Stock Information")]
    public string names;
    public float price;
    public uint count;
    public uint ID;
    public float rate;
    public float MinRate;
    public float MaxRate;
    public StockPriceManager SPM;
    myStock()
    {
        price = 0.01f;
      
        rate = 0.046f;
    }

}
