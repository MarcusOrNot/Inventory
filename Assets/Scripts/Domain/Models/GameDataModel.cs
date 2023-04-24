using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [System.Serializable]
    public class GameDataModel
    {
        public int Money;
        public int UnblockedSlotsCount;
        public List<InventoryItemModel> Items;

        public GameDataModel(int money, int unblocked, List<InventoryItemModel> items)
        {
            Money = money;
            UnblockedSlotsCount = unblocked;
            Items = items;
        }
    }
}
