using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public interface IContainerInventory
    {
        public List<ISlot> GetSlots();
        public void AddItemByModel(InventoryItemModel modelData, ISlot inSlot);
        public void UnblockSlot();
    }
}
