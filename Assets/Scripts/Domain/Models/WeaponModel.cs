using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [System.Serializable]
    public class WeaponModel : InventoryItemModel
    {
        public WeaponType Weapon;
        [SerializeField] public int Damage;

        /*public WeaponType Weapon => _weapon;
        public int Damage => _damage; */

        public WeaponModel(WeaponType weapon, int damage, Sprite icon, float weight, int count) : base(ItemType.Weapon, icon, weight, count)
        {
            Weapon = weapon;
            Damage = damage;
        }
    }
}
