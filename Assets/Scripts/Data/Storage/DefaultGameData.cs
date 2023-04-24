using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [CreateAssetMenu(fileName = "Default Settings", menuName = "GameSettings")]
    public class DefaultGameData : ScriptableObject
    {
        public int StartMoney = 300;
        public int StartBlocked = 15;
        public int UnblockPrice = 20;
    }
}
