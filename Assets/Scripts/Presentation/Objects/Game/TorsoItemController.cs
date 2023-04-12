using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class TorsoItemController : InventoryItemController, ITorso
    {
        public TorsoModel GetTorsoModel()
        {
            return (TorsoModel)ItemData;
        }

        public override bool IsSameItemClass(InventoryItemController item)
        {
            return (item is TorsoItemController && ((TorsoModel) item.ItemData).Torso==GetTorsoModel().Torso);
        }

        /*public override bool IsSameItemClass(InventoryItemModel model)
        {
            return ( model!=null);
        }*/
    }
}
