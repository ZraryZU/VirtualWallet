using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class Item
    {
        public uint itemId;  //uint为无符号整型。
        public string itemName;
        public uint itemPrice;
        public uint itemCount;
        public float minRate;
        public float maxRate;
    }
   // [CreateAssetMenu(fileName = "New iData", menuName = "Character Stats/iData")]
    public class ItemManager : ScriptableObject
    {
        public Item[] dataArray;
    }
}