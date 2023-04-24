using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [CreateAssetMenu(fileName = "Weapon Data", menuName = "Inventory/Weapon")]
    public class WeaponData : InventoryItemData
    {
        [SerializeField] private WeaponType _weapon;
        [SerializeField] private int _damage;

        public WeaponType Weapon => _weapon;
        public int Damage => _damage;

        public override ItemType GetItemType()
        {
            return ItemType.Weapon;
        }
    }
}
