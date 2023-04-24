using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [CreateAssetMenu(fileName = "Torso Data", menuName = "Inventory/Torso")]
    public class TorsoData : InventoryItemData
    {
        [SerializeField] private TorsoType _torso;
        [SerializeField] private int _defence;
        public TorsoType Torso => _torso;
        public int Deffence => _defence;

        public override ItemType GetItemType()
        {
            return ItemType.Torso;
        }
    }
}
