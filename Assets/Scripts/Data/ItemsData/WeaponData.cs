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

        public override void SetData(InventoryItemModel model)
        {
            WeaponModel data = (WeaponModel)model;
            _weight = data.Weight;
            _icon = data.Icon;
            _weapon = data.Weapon;
            _damage = data.Damage;
        }

        /*public override InventoryItemModel GetModel()
        {
            return new WeaponModel(Weapon, Damage, Icon, Weight, 0);
        }*/
    }
}
