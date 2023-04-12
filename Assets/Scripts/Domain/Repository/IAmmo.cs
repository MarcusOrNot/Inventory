using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public interface IAmmo: IItem
    {
        public AmmoModel GetAmmoData();
    }
}
