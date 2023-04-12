using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [CreateAssetMenu(fileName = "Storage Data", menuName = "Inventory Storage")]
    public class InventoryStorage: ScriptableObject
    {
        public int UnblockedSlots = 15;
        public float UnblockPrice;
        public List<InventoryItemModel> Items;
        //public List<InventoryStorageElem> Items;

        /*public int UnblockSlots => _unblockedSlots;
        public float UnblockPrice => _unblockPrice;
        public List<InventoryStorageElem> Items => _inventoryItems; */
    }
}
