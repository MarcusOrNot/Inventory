using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [CreateAssetMenu(fileName = "Ammo Data", menuName = "Inventory/Ammo")]
    public class AmmoData : InventoryItemData
    {
        [SerializeField] private AmmoType _ammoType;
        [SerializeField] private int _maxCount;

        public AmmoType AmmoType => _ammoType;
        public int MaxCount => _maxCount;

        public override ItemType GetItemType()
        {
            return ItemType.Ammo;
        }
    }
}
