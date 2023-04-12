using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public abstract class InventoryItemData : ScriptableObject
    {
        //[SerializeField] private ItemType _itemType;
        [SerializeField] protected float _weight;
        [SerializeField] protected Sprite _icon;

        //public ItemType ItemType => _itemType;
        public float Weight => _weight;
        public Sprite Icon => _icon;
        //public abstract InventoryItemModel GetModel ();
        public abstract ItemType GetItemType();
        public abstract void SetData(InventoryItemModel model);
    }
}
