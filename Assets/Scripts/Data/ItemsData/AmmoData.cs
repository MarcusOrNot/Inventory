using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [CreateAssetMenu(fileName = "Ammo Data", menuName = "Inventory/Ammo")]
    public class AmmoData : InventoryItemData
    {
        [SerializeField] private WeaponType _weaponAmmo;
        [SerializeField] private int _maxCount;

        public WeaponType WeaponAmmo => _weaponAmmo;
        public int MaxCount => _maxCount;

        public override ItemType GetItemType()
        {
            return ItemType.Ammo;
        }

        public override void SetData(InventoryItemModel model)
        {
            AmmoModel data = (AmmoModel)model;
            _weight = data.Weight;
            _icon = data.Icon;
            _weaponAmmo = data.WeaponAmmo;
            _maxCount = data.MaxCount;
        }
    }
}
