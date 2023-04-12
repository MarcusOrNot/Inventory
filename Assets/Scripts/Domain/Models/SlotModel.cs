using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class SlotModel
    {
        public bool IsLocked;
        public SlotModel(bool isLocked)
        {
            IsLocked = isLocked;
        }
    }
}
