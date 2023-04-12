using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public interface IContainerInventory
    {
        //public List<InventoryItemController> GetItemsByType(ItemType itemType);
        public List<ISlot> GetSlots();
        //public List<ISlot> GetEmptySlots();
        public void AddItemByModel(InventoryItemModel modelData, ISlot inSlot);
        //public InventoryItemController LoadItem(InventoryStorageElem data, SlotManager inSlot);
        public void UnblockSlot();
        public void SaveCurrentData();
    }
}
