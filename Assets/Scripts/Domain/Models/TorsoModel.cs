using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class TorsoModel: InventoryItemModel
    {
        public TorsoType Torso;
        public int Deffence;
        public TorsoModel(TorsoType torso, int deffence, Sprite icon, float weight, int count) : base(ItemType.Torso, icon , weight, count)
        {
            Torso = torso;
            Deffence = deffence;
        }
    }
}
