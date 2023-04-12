using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public interface ITorso: IItem
    {
        public TorsoModel GetTorsoModel();
    }
}
