using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public interface ISlot
    {
        public InventoryItemModel GetModel();
        public void DestroySlotItem();
        public bool IsEmpty();
        public void SetLockedView(bool isLocked);
        public void DetachSlotItem();
        public void PutItem(InventoryItemController item);
    }
}
