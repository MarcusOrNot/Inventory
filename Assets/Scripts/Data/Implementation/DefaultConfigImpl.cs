using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class DefaultConfigImpl : IDefaultConfig
    {
        [Inject] private DefaultGameData _defaultData;
        public int GetDefaultBlockedSlots()
        {
            return _defaultData.StartBlocked;
        }

        public int GetDefaultMoney()
        {
            return _defaultData.StartMoney;
        }

        public int GetUnblockPrice()
        {
            return _defaultData.UnblockPrice;
        }
    }
}
