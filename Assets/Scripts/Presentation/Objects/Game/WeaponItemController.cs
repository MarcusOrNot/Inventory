using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class WeaponItemController : InventoryItemController, IWeapon
    {
        private WeaponModel _weaponData;
        public WeaponModel GetWeaponData()
        {
            return _weaponData;
        }
        public override bool IsSameItemClass(GameObject item)
        {
            IWeapon current = item.GetComponent<IWeapon>();
            if (current != null && current.GetWeaponData().Weapon == _weaponData.Weapon) return true;
            return false;
        }
        public override void SetData<T>(T itemData)
        {
            _weaponData = itemData as WeaponModel;
            RefreshView();
        }
        protected override InventoryItemModel GetData()
        {
            return _weaponData;
        }
    }
}
