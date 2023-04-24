using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public abstract class InventoryItemData : ScriptableObject
    {
        [SerializeField] protected float _weight;
        [SerializeField] protected Sprite _icon;
        public float Weight => _weight;
        public Sprite Icon => _icon;
        public abstract ItemType GetItemType();
    }
}
