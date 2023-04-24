using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public interface IDefaultConfig
    {
        public int GetDefaultMoney();
        public int GetDefaultBlockedSlots();
        public int GetUnblockPrice();
    }
}
