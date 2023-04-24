using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [System.Serializable]
    public class InventoryItemModel
    {
        public ItemType Item;
        public int ItemVersion;
        public Sprite Icon;
        public float Weight;
        public int Count;

        public InventoryItemModel(ItemType itemType, int itemVersion, Sprite icon, float weight, int count)
        {
            Item = itemType;
            ItemVersion = itemVersion;
            Icon = icon;
            Weight = weight;
            Count = count;
        }
        
    }
}
