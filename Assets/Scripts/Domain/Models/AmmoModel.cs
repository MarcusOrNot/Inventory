using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class AmmoModel : InventoryItemModel
    {
        public AmmoType AmmoType;
        public int MaxCount;
        public AmmoModel(AmmoType ammoType, int maxCount, Sprite icon, float weight, int count) : base(ItemType.Ammo, (int) ammoType, icon, weight, count)
        {
            AmmoType = ammoType;
            MaxCount = maxCount;
        }
    }
}
