using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [System.Serializable]
    public class InventoryItemModel
    {
        [HideInInspector] public ItemType Item;
        [HideInInspector] public Sprite Icon;
        [HideInInspector] public float Weight;
        [HideInInspector] public int Count;

        public InventoryItemModel(ItemType itemType, Sprite icon, float weight, int count)
        {
            Item = itemType;
            Icon = icon;
            Weight = weight;
            Count = count;
        }
        
    }
}
