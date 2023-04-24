using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [CreateAssetMenu(fileName = "Head Data", menuName = "Inventory/Head")]
    public class HeadData : InventoryItemData
    {
        [SerializeField] private HeadType _head;
        [SerializeField] private int _defence;
        public HeadType Head => _head;
        public int Defence => _defence;

        public override ItemType GetItemType()
        {
            return ItemType.Head;
        }
    }
}
