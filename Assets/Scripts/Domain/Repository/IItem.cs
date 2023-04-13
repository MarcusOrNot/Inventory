using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public interface IItem
    {
        public InventoryItemModel ItemData { get; }
        public void RefreshView();
        public void DestroyItem();
    }
}
