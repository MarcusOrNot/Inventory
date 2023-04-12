using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class WeaponItemController : InventoryItemController, IWeapon
    {

        public WeaponModel GetWeaponData()
        {
            return (WeaponModel)ItemData;
        }

        public override bool IsSameItemClass(InventoryItemController item)
        {
            //WeaponItemController some = (WeaponItemController) item;
            //Debug.Log("Weapon is "+some.GetWeaponData().Weapon.ToString());
            return (item is WeaponItemController && ((WeaponItemController) item).GetWeaponData().Weapon == GetWeaponData().Weapon);
        }

        /*public override bool IsSameItemClass(InventoryItemModel model)
        {
            return (model is WeaponModel); 
        } */
    }
}
