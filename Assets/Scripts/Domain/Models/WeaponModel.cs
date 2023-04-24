using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class WeaponModel : InventoryItemModel
    {
        public WeaponType Weapon;
        public int Damage;
        public WeaponModel(WeaponType weapon, int damage, Sprite icon, float weight, int count) : base(ItemType.Weapon, (int) weapon, icon, weight, count)
        {
            Weapon = weapon;
            Damage = damage;
        }
    }
}
