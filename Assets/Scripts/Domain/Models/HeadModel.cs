using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class HeadModel: InventoryItemModel
    {
        public HeadType Head;
        public int Deffence;
        public HeadModel(HeadType head, int deffence, Sprite icon, float weight, int count) : base(ItemType.Head, (int) head, icon, weight, count)
        {
            Head = head;
            Deffence = deffence;
        }
    }
}
