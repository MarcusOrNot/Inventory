using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class AmmoModel : InventoryItemModel
    {
        public WeaponType WeaponAmmo;
        public int MaxCount;
        public AmmoModel(WeaponType weaponAmmo, int maxCount, Sprite icon, float weight, int count) : base(ItemType.Ammo, icon, weight, count)
        {
            WeaponAmmo = weaponAmmo;
            MaxCount = maxCount;
        }
    }
}
