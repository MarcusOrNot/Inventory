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

        /*public override void SetData(InventoryItemModel model)
        {
            HeadModel data = (HeadModel)model;
            _weight = data.Weight;
            _icon = data.Icon;
            _defence = data.Deffence;
        } */
    }
}
